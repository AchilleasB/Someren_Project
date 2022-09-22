using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class ForgotPasswordService
    {
        ForgotPasswordDao forgotPassworddb;

        public ForgotPasswordService()
        {
            forgotPassworddb = new ForgotPasswordDao();
        }

        public string GetSecretQuestion(string username) 
        {
            string question = forgotPassworddb.GetSecretQuestion(username);
            return question;
        }
        public string GetSecretAnswer(string username)
        {
            string answer = forgotPassworddb.GetSecretAnswer(username);
            return answer;
        }
        public void ChangePassword(User user) 
        {
            forgotPassworddb.ChangePassword(user);
        }
        public void ChangeSecretQuestion(string username, string question, string answer)
        {
            forgotPassworddb.ChangeSecretQuestion(username, question, answer);
        }
    }
}
