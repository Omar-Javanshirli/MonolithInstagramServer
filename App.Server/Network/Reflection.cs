using App.Business.Concrete;
using App.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Server.Network
{
    public class Reflection
    {
        private static readonly Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static readonly List<Socket> clientSockets = new List<Socket>();
        private const int BUFFER_SIZE = 4096;
        private static readonly byte[] buffer = new byte[BUFFER_SIZE];

        static public void Start()
        {
            Console.Title = "Server";
            SetupServer();
            Console.ReadLine(); // When we press enter close everything
            CloseAllSockets();
        }

        private static void SetupServer()
        {
            Console.WriteLine("Setting up server...");
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse(NetworkProtocol.IPAddress), NetworkProtocol.TcpPort));
            serverSocket.Listen(0);
            serverSocket.BeginAccept(AcceptCallback, null);
            Console.WriteLine("Server setup complete");
        }

        private static void AcceptCallback(IAsyncResult AR)
        {
            Socket socket;

            try
            {
                socket = serverSocket.EndAccept(AR);
            }
            catch (ObjectDisposedException) // I cannot seem to avoid this (on exit when properly closing sockets)
            {
                return;
            }
            SendServiceResponseToClient(socket);
            clientSockets.Add(socket);
            socket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, socket);
            Console.WriteLine("Client connected, waiting for request...");
            serverSocket.BeginAccept(AcceptCallback, null);
        }

        private static void SendServiceResponseToClient(Socket client)
        {
            var result = GetAllServiceAsText();
            byte[] data = Encoding.ASCII.GetBytes(result);
            client.Send(data);
        }

        public static string GetAllServiceAsText()
        {
            var myTypes = Assembly.GetAssembly(typeof(UserService)).GetTypes()
                .Where(m => m.Name.EndsWith("Service") && !m.Name.StartsWith("I"));

            var sb = new StringBuilder();
            foreach (var type in myTypes)
            {
                var className = type.Name.Remove(type.Name.Length - 7, 7);
                var methods = type.GetMethods().Reverse().Skip(4);
                foreach (var m in methods)
                {
                    string responseText = $@"{className}\{m.Name}";
                    var parameters = m.GetParameters();
                    foreach (var p in parameters)
                    {
                        //p.ParameterType.IsClass
                        if (p.ParameterType != typeof(string) && p.ParameterType.IsClass)
                        {
                            responseText += $@"\{p.Name}[json]";
                        }
                        else
                        {
                            responseText += $@"\{p.Name}";
                        }
                    }
                    sb.AppendLine(responseText);
                }
            }

            var result = sb.ToString();
            return result;
        }

        private static void ReceiveCallback(IAsyncResult AR)
        {
            Socket current = (Socket)AR.AsyncState;
            int received;

            try
            {
                received = current.EndReceive(AR);
            }
            catch (SocketException)
            {
                Console.WriteLine("Client forcefully disconnected");
                // Don't shutdown because the socket may be disposed and its disconnected anyway.
                current.Close();
                clientSockets.Remove(current);
                return;
            }

            byte[] recBuf = new byte[received];
            Array.Copy(buffer, recBuf, received);
            string msg = Encoding.ASCII.GetString(recBuf);
            Console.WriteLine("Received Text: " + msg);

            SendData(msg, current);
            current.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, current);
        }

        private static void CloseAllSockets()
        {
            foreach (Socket socket in clientSockets)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }

            serverSocket.Close();
        }

        private static void SendData(string msg, Socket current)
        {
            if (msg != String.Empty)
            {
                try
                {
                    var result = msg.Split(new[] { ' ' }, 2);
                    if (result.Length >= 2)
                    {
                        var jsonPart = result[1];

                        var subResult = result[0].Split('\\');
                        var className = subResult[0];
                        var methodName = subResult[1];

                        var myType = Assembly.GetAssembly(typeof(UserService)).GetTypes()
                        .FirstOrDefault(a => a.FullName.Contains(className));

                        var myEntitiesType = Assembly.GetAssembly(typeof(User)).GetTypes()
                        .FirstOrDefault(a => a.FullName.Contains(className));

                        var obj = JsonConvert.DeserializeObject(jsonPart, myEntitiesType);

                        var methods = myType.GetMethods();
                        MethodInfo myMethod = myType.GetMethods()
                        .FirstOrDefault(m => m.Name.Contains(methodName));

                        object myInstance = Activator.CreateInstance(myType);
                        myMethod.Invoke(myInstance, new object[1] { obj });
                        byte[] data = Encoding.ASCII.GetBytes("Successfully POST Operation");
                        current.Send(data);
                    }
                    else
                    {
                        result = msg.Split('\\');
                        var className = result[0];
                        var methodName = result[1];

                        var myType = Assembly.GetAssembly(typeof(UserService)).GetTypes()
                        .FirstOrDefault(a => a.FullName.Contains(className + "Service"));

                        var methods = myType.GetMethods();
                        MethodInfo myMethod = myType.GetMethods()
                        .FirstOrDefault(m => m.Name.Contains(methodName));

                        object myInstance = Activator.CreateInstance(myType);

                        dynamic paramId = -1;
                        var jsonString = String.Empty;
                        object objectResponse = null;
                        if (result.Length == 3)
                        {
                            paramId = result[2];
                            objectResponse = myMethod.Invoke(myInstance, new object[1] { paramId });
                        }
                        else
                        {
                            objectResponse = myMethod.Invoke(myInstance, null);
                        }

                        jsonString = JsonConvert.SerializeObject(objectResponse);
                        byte[] data = Encoding.ASCII.GetBytes(jsonString);
                        current.Send(data);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            else if (msg.ToLower() == "exit")
            {
                // Always Shutdown before closing
                current.Shutdown(SocketShutdown.Both);
                current.Close();
                clientSockets.Remove(current);
                Console.WriteLine("Client disconnected");
                return;
            }

            else
            {
                Console.WriteLine("Query is an invalid request");
                byte[] data = Encoding.ASCII.GetBytes("Invalid request");
                current.Send(data);
                Console.WriteLine("Warning Sent");
            }
        }
    }
}
