using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SomerenModel;

namespace SomerenDAL
{
    public class RegistrationDao : BaseDao
    {
        public void CreateUser(User user)
        {
            string query = "INSERT INTO Users (Username, Digest, Salt, Name, Email, Role, SecretQuestion, SecretAnswer)" +
                " values(@Username, @Digest, @Salt, @Name, @Email, @Role, @SecretQuestion, @SecretAnswer)";
            SqlParameter[] sqlParameters = new SqlParameter[8];
            sqlParameters[0] = new SqlParameter("@Username", user.Username);
            sqlParameters[1] = new SqlParameter("@Digest", user.Digest);
            sqlParameters[2] = new SqlParameter("@Salt", user.Salt);
            sqlParameters[3] = new SqlParameter("@Name", user.Name);
            sqlParameters[4] = new SqlParameter("@Email", user.Email);
            sqlParameters[5] = new SqlParameter("@Role", user.Role);
            sqlParameters[6] = new SqlParameter("@SecretQuestion", user.SecretQuestion);
            sqlParameters[7] = new SqlParameter("@SecretAnswer", user.SecretAnswer);

            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
