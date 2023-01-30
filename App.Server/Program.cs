using App.Business.Concrete;
using App.DataAccess.Concrete.EfEntityFramework;
using App.Server.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Server
{
    public class Program
    {
        static void Main(string[] args)
        {
            Reflection.Start();
        }
    }
}
