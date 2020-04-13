using System;
using System.IO;
using System.Configuration;
using System.Linq;
using ShoppingCart.Business.Repository.Interfaces;

namespace ShoppingCart.Business
{
    public class GroceriesRepository : ProductsRepository, IGroceriesRepository
    {
        private string path = ConfigurationManager.AppSettings["GroceryDatabase"];

        public static int objectCount = 0;
        public GroceriesRepository()
        {
            objectCount += 1;
            string[] readLines = File.ReadAllLines(path);

            foreach (string line in readLines.Skip(1))
            {
                string[] values = line.Split(',');
                GroceryList.Add(new Item(values[0], Convert.ToInt32(values[1]), Convert.ToDouble(values[2])));
            }
        }
    }
}