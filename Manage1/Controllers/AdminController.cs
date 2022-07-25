using Core.Entities;
using Core.Helpers;
using DataAccess.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage1.Controllers
{
    public class AdminController
    {
        private AdminRepositories _adminRepositories;
        public AdminController()
        {
          _adminRepositories  = new AdminRepositories();   
        }
    
      public Admin Authenticate()
        {
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "enter admin username:");
            string userName = Console.ReadLine();

            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Cyan, "enter admin password:");
            string password = Console.ReadLine();

            var admin = _adminRepositories.Get(a => a.UserName.ToLower() == userName.ToLower()
                                             && PasswordHasher.Decrypt(a.Password) == password);
                return admin;
        }
    
    }
}
