using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int StudentId { get; set; } // LecturerNumber, e.g. 47198
        public int DrinkId { get; set; }
        public DateTime DateOfPurchase { get; set; }
    }
}
