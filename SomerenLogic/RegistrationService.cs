using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class RegistrationService
    {
        RegistrationDao registrationdb;

        public RegistrationService()
        {
            registrationdb = new RegistrationDao();
        }

        public void AddUser(User user)
        {
            registrationdb.CreateUser(user);
        }

        public bool ValidatePassword(string password)
        {
            bool hasSpecialChar = false;

            Regex hasNumber = new Regex(@"[0-9]+");
            Regex hasUpperChar = new Regex(@"[A-Z]+");
            Regex hasLowerChar = new Regex(@"[a-z]+");
            Regex hasMinimum8Chars = new Regex(@".{8,}");

            for (int i = 0; i < password.Length; i++)
            // check if one of the chars is not number and not upper/lower letter
            // to string since we are validating char and regex match accept only strings
                if (!hasNumber.IsMatch(password[i].ToString())
                && !hasUpperChar.IsMatch(password[i].ToString())
                && !hasLowerChar.IsMatch(password[i].ToString()))
                    hasSpecialChar = true;

            // return true meet all password requirements
            return hasSpecialChar
                && hasNumber.IsMatch(password)
                && hasUpperChar.IsMatch(password)
                && hasLowerChar.IsMatch(password)
                && hasMinimum8Chars.IsMatch(password);
        }

        public bool ValidateLicenseKey(string licenseKey)
        {
            return licenseKey.Equals("XsZAb - tgz3PsD - qYh69un - WQCEx");
        }
    }
}
