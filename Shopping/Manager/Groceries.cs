using System;
using System.IO;
using GroceryStore;
using System.Configuration;


namespace Shopping
{
    public class Groceries : Products
    {
        private string location_of_csv_file = ConfigurationManager.AppSettings["GroceryDatabase"];

        public Groceries()
        {
            string[] readLines = File.ReadAllLines(location_of_csv_file);

            foreach (string line in readLines)
            {
                /* Ignore the title row */
                if (line.Contains("name"))
                {
                    continue;
                }

                string[] values = line.Split(',');
                GroceryLists.Add(new Item(values[0], Convert.ToInt32(values[1]), Convert.ToDouble(values[2])));
            }
        }

        public override void ShowGroceries()
        {
            foreach (Item item in GroceryLists)
            {
                Console.WriteLine($"Name: {item.Name}, BarCode: {item.BarCode}, Price: {item.Price}");
            }
        }
    }
}
