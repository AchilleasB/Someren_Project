using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class LoginService
    {
        LoginDao logindb;

        public LoginService()
        {
            logindb = new LoginDao();
        }

        public User GetRegisteredUser(string username)
        {
            return logindb.GetRegisteredUser(username);
        }
 
    }
}
