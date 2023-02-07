using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Pattern.Proxsy
{
    public class CacheProxsy : ICache
    {
        public Task<User> GetUser(string username)
        {
            throw new NotImplementedException();
        }
    }
}
