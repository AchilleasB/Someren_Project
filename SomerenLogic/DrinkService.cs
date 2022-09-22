using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenModel;
using SomerenDAL;
using System.Windows.Forms;

namespace SomerenLogic
{
    public class DrinkService
    {
        DrinkDao drinkdb;

        public DrinkService()
        {
            drinkdb = new DrinkDao();
        }

        public List<Drink> GetDrinks()
        {
            return drinkdb.GetAllDrinks();
        }

        public Drink GetDrink(int drinkId)
        {
            return drinkdb.GetDrinkById(drinkId);
        }

        public void AddDrink(Drink drink)
        {
            drinkdb.CreateDrink(drink);
        }

        public void UpdateDrink(Drink drink)
        {
            drinkdb.UpdateDrink(drink);
        }

        public void DeleteDrink(int drinkId)
        {
            drinkdb.DeleteDrink(drinkId);
        }
    }
}
