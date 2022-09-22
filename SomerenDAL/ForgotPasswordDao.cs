using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;

namespace SomerenDAL
{
    public class ForgotPasswordDao : BaseDao
    {
        public string GetSecretQuestion(string username)
        {
            string query = "SELECT SecretQuestion FROM Users WHERE Username = @username";

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@username", username);

            return ReadSecretQuestion(ExecuteSelectQuery(query, sqlParameters));
        }

        private string ReadSecretQuestion(DataTable dataTable)
        {
            string question = "";

            foreach (DataRow s in dataTable.Rows)
            {
                question = (string)s["SecretQuestion"];
            }
            return question;
        }

        public string GetSecretAnswer(string username)
        {
            string query = "SELECT SecretAnswer AS SecretQuestion FROM Users WHERE Username = @username";

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@username", username);

            return ReadSecretQuestion(ExecuteSelectQuery(query, sqlParameters));
        }

        public void ChangePassword(User user)
        {
            string query1 = "UPDATE Users SET Digest = @Digest WHERE Username = @Username";
            string query2 = "UPDATE Users SET Salt = @Salt WHERE Username = @Username";

            SqlParameter[] sqlParameters1 = new SqlParameter[2];
            sqlParameters1[0] = new SqlParameter("@Digest", user.Digest);
            sqlParameters1[1] = new SqlParameter("@Username", user.Username);

            //sqlParameters[1] = new SqlParameter("@password", password);
            SqlParameter[] sqlParameters2 = new SqlParameter[2];
            sqlParameters2[0] = new SqlParameter("@Salt", user.Salt);
            sqlParameters2[1] = new SqlParameter("@Username", user.Username);


            ExecuteEditQuery(query1, sqlParameters1);
            ExecuteEditQuery(query2, sqlParameters2);
        }

        public void ChangeSecretQuestion(string username, string question, string answer)
        {
            string query = "UPDATE Users SET Users.[SecretQuestion] = @question, Users.[SecretAnswer] = @answer WHERE Users.[Username] = @username";

            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@username", username);
            sqlParameters[1] = new SqlParameter("@question", question);
            sqlParameters[2] = new SqlParameter("@answer", answer);

            ExecuteEditQuery(query, sqlParameters);
        }
    }
}