using System;
using System.IO;
using System.Configuration;
using System.Linq;
using ShoppingCart.Business.Repository.Interfaces;
using ShoppingCart.Business.Data;
using System.Collections.Generic;

namespace ShoppingCart.Business
{
    public class GroceriesRepository : ProductsRepository, IGroceriesRepository
    {
        public override List<Item> ProductList => Database.GroceryList;

        private readonly string path = ConfigurationManager.AppSettings["GroceryDatabase"];

        public GroceriesRepository()
        {
            string[] readLines = File.ReadAllLines(path);

            foreach (string line in readLines.Skip(1))
            {
                string[] values = line.Split(',');
                ProductList.Add(new Item(values[0], Convert.ToInt32(values[1]), Convert.ToDouble(values[2])));
            }
        }
    }
}