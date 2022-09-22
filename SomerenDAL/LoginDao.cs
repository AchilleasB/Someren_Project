using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class LoginDao : BaseDao
    {
        public User GetRegisteredUser(string username)
        {
            string query = "SELECT Digest, Salt FROM [Users] WHERE Username = @Username";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Username", username);
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private User ReadTables(DataTable dataTable)
        {
            User user = null;

            foreach (DataRow dr in dataTable.Rows)
            {
                user = new User()
                {
                    Digest = (string)dr["Digest"],
                    Salt = (string)dr["Salt"],
                };
            }
            return user;
        }
    }
}
