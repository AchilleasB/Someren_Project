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
    public class PurchaseService
    {
        PurchaseDao purchasedb;

        public PurchaseService()
        {
            purchasedb = new PurchaseDao();
        }

        public void InsertPurchase(Student student, Drink drink)
        {
            purchasedb.InsertAnyPurchase(student, drink);
        }

        public void UpdateStock(Drink drink)
        {
            purchasedb.UpdateStock(drink);
        }
    }
}
