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
    public class RevenueService
    {
        RevenueDao purchasedb;

        public RevenueService()
        {
            purchasedb = new RevenueDao();
        }

        public List<Purchase> GetPurchases()
        {
            List<Purchase> purchases = purchasedb.GetAllPurchases();
            return purchases;
        }
        public int GetNumberOfSales(DateTime startDate, DateTime endDate) 
        {
            int numberOfSales = purchasedb.GetNumberOfSales(startDate, endDate);
            return numberOfSales;
        }
        public int GetNumberOfCustomers(DateTime startDate, DateTime endDate) 
        {
            int numberOfCustomers = purchasedb.GetNumberOfCustomers(startDate, endDate);
            return numberOfCustomers;
        }
        public decimal GetTurnover(DateTime startDate, DateTime endDate) 
        {
            decimal turnover = purchasedb.GetTurnover(startDate, endDate);
            return turnover;
        }
    }
}
