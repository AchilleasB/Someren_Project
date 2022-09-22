using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;
using System.Globalization;

namespace SomerenDAL
{
    public class RevenueDao : BaseDao
    {
        public List<Purchase> GetAllPurchases()
        {
            string query = $"SELECT PurchaseId, StudentId, DrinkId, DateOfPurchase FROM [Purchases]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        private List<Purchase> ReadTables(DataTable dataTable)
        {
            List<Purchase> purchases = new List<Purchase>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Purchase purchase = new Purchase()
                {
                    PurchaseId = (int)dr["PurchaseId"],
                    StudentId = (int)dr["StudentID"],
                    DrinkId = (int)dr["DrinkId"],
                    DateOfPurchase = (DateTime)dr["DateOfPurchase"]
                };
                purchases.Add(purchase);
            }
            return purchases;
        }
        private int ReadNumberOfSales(DataTable dataTable)
        {
            int purchases = 0;

            foreach (DataRow s in dataTable.Rows)
            {
                purchases = ((int)s["NumberOfSales"]);
            }
            return purchases;
        }
        private int ReadNumberOfCustomers(DataTable dataTable)
        {
            int purchases = 0;

            foreach (DataRow s in dataTable.Rows)
            {
                purchases = ((int)s["NumberOfCustomers"]);
            }
            return purchases;
        }
        private decimal ReadPrice(DataTable dataTable)
        {
            decimal price = 0;

            foreach (DataRow s in dataTable.Rows)
            {
                price = (decimal)s["DrinkPrice"];
            }
            return price;
        }
        public int GetNumberOfSales(DateTime startDate, DateTime endDate)
        {
            string query = "SELECT COUNT(*) as NumberOfSales FROM [Purchases] WHERE DateOfPurchase >= @startDate AND DateOfPurchase <= @endDate";

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@startDate", startDate.ToString("yyyy-MM-dd"));
            sqlParameters[1] = new SqlParameter("@endDate", endDate.ToString("yyyy-MM-dd"));

            return ReadNumberOfSales(ExecuteSelectQuery(query, sqlParameters));
        }
        public int GetNumberOfCustomers(DateTime startDate, DateTime endDate)
        {
            string query = "SELECT COUNT(DISTINCT StudentId) AS NumberOfCustomers FROM purchases WHERE DateOfPurchase >= @startDate AND DateOfPurchase <= @endDate";

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@startDate", startDate.ToString("yyyy-MM-dd"));
            sqlParameters[1] = new SqlParameter("@endDate", endDate.ToString("yyyy-MM-dd"));

            return ReadNumberOfCustomers(ExecuteSelectQuery(query, sqlParameters));
        }
        public decimal GetTurnover(DateTime startDate, DateTime endDate)
        {
            List<Purchase> purchases = GetAllPurchases();
            decimal turnover = 0;

            foreach (Purchase p in purchases)
            {
                if ((p.DateOfPurchase > startDate) && (p.DateOfPurchase < endDate))
                {
                    int drinkID = p.DrinkId;
                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@drinkID", drinkID);

                    string query = "SELECT DrinkPrice FROM [Drinks] WHERE DrinkId = @drinkID";
                    decimal purchasePrice = ReadPrice(ExecuteSelectQuery(query, sqlParameters));

                    turnover += purchasePrice;
                }
            }
            return turnover;    
        }
    }
}
