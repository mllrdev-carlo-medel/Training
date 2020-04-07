using System;
using System.IO;

namespace Shopping
{
    public class Item
    {

        public string Name { get; set; }
        public int BarCode { get; set; }
        public double Price { get; set; }

        public Item (string name = "No name",
                     int barcode = 0,
                     double price = 0.0)
        {
            Name = name;
            BarCode = barcode;
            Price = price;
        }
    }
}
