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
    public class DrinkDao : BaseDao
    {


        public List<Drink> GetAllDrinks()
        {
            string query = "SELECT DrinkId, NameOfDrink, DrinkType, DrinkPrice, Stock, Sold FROM [Drinks] ORDER BY NameOfDrink";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Drink> ReadTables(DataTable dataTable)
        {
            List<Drink> drinks = new List<Drink>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Drink drink = new Drink()
                {
                    Id = (int)dr["DrinkId"],
                    Name = (string)dr["NameOfDrink"],
                    isAlcoholic = (bool)dr["DrinkType"],
                    Price = (decimal)dr["DrinkPrice"],
                    Stock = (int)dr["Stock"],
                    Sold = (int)dr["Sold"]
                };
                drinks.Add(drink);
            }
            return drinks;
        }

        public Drink GetDrinkById(int drinkId)
        {
            string query = "SELECT * FROM [Drinks] WHERE DrinkId = @DrinkId";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@DrinkId", drinkId);
            return ReadTables(ExecuteSelectQuery(query, sqlParameters))[0];
        }

        public void CreateDrink(Drink drink)
        {
            string query = "INSERT INTO Drinks(NameOfDrink, DrinkType, DrinkPrice, Stock, Sold) values(@NameOfDrink, @DrinkType, @DrinkPrice, @Stock, @Sold)";
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@NameOfDrink", drink.Name);
            sqlParameters[1] = new SqlParameter("@DrinkType", Convert.ToInt32(drink.isAlcoholic));
            sqlParameters[2] = new SqlParameter("@DrinkPrice", drink.Price);
            sqlParameters[3] = new SqlParameter("@Stock", drink.Stock);
            sqlParameters[4] = new SqlParameter("@Sold", drink.Sold);
            ExecuteEditQuery(query, sqlParameters);
        }

        public void UpdateDrink(Drink drink)
        {
            string query = "UPDATE [Drinks] SET NameOfDrink = @NameOfDrink, DrinkType = @DrinkType, DrinkPrice = @DrinkPrice, Stock = @Stock, Sold = @Sold WHERE DrinkId = @DrinkId";
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@NameOfDrink", drink.Name);
            sqlParameters[1] = new SqlParameter("@DrinkType", Convert.ToInt32(drink.isAlcoholic));
            sqlParameters[2] = new SqlParameter("@DrinkPrice", drink.Price);
            sqlParameters[3] = new SqlParameter("@Stock", drink.Stock);
            sqlParameters[4] = new SqlParameter("@DrinkId", drink.Id);
            sqlParameters[5] = new SqlParameter("@Sold", drink.Sold);
            ExecuteEditQuery(query, sqlParameters);
        }

        public void DeleteDrink(int drinkId)
        {
            string query = "DELETE FROM [Drinks] WHERE DrinkId = @DrinkId";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@DrinkId", drinkId);
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
