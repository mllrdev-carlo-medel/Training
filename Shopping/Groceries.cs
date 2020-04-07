using System;
using System.Collections.Generic;
using System.IO;

namespace Shopping
{
    public class Groceries : IGetItemByBarcode, IGetItemByName
    {
       protected List<Item> GroceryLists = new List<Item>();

        public Groceries() { }

        public Groceries(string location_of_csv_file)
        {
            StreamReader reader = new StreamReader(File.OpenRead(@location_of_csv_file));

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                /* Ignore the title row */
                if (line.Contains("name"))
                    continue;

                string[] values = line.Split(',');
                GroceryLists.Add(new Item(values[0], Convert.ToInt32(values[1]), Convert.ToDouble(values[2])));
            }
        }

        public virtual void ShowGroceries ()
        {
            foreach (Item i in GroceryLists)
            {
                Console.WriteLine ("Name: {0}, BarCode: {1}, Price: {2}", i.Name, i.BarCode, i.Price);
            }
        }

        public Item GetItemByBarCode(int barcode)
        {
            foreach (Item i in GroceryLists)
            {
                if (i.BarCode == barcode)
                    return i;
            }

            Console.WriteLine("Item: {0} can't be found", barcode);
            return null;
        }

        public Item GetItemByName(string name)
        {
            foreach (Item i in GroceryLists)
            {
                if (i.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return i;
            }

            Console.WriteLine("Item: {0} can't be found", name);
            return null;
        }
    }
}
