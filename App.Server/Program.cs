using App.Business.Concrete;
using App.DataAccess.Concrete.EfEntityFramework;
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
            var userService=new UserService(new UserDal());
            var users = userService.GetAllAsync();
        }
    }
}
