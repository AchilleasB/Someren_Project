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
    public class PurchaseDao : BaseDao
    {
        public void InsertAnyPurchase(Student student, Drink drink)
        {
            string query = "INSERT INTO Purchases (StudentId, DrinkId, DateOfPurchase) VALUES ( @StudentId, @DrinkId, GETDATE() )";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@StudentId", student.Number);
            sqlParameters[1] = new SqlParameter("@DrinkId", drink.Id);
            ExecuteEditQuery(query, sqlParameters);
        }


        public void UpdateStock(Drink drink)
        {
            string query = "UPDATE [Drinks] SET Stock = @Stock - 1 WHERE  DrinkId = @DrinkId";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@DrinkId", drink.Id);
            sqlParameters[1] = new SqlParameter("@Stock", drink.Stock);
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
