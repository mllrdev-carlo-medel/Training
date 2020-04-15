using System;
using System.Collections.Generic;

namespace ShoppingCart.Business
{
    public abstract class BaseRepository
    {
        public abstract List<Item> ProductList { get; }

        public Item GetByBarcode(int barcode)
        {
            foreach (Item item in ProductList)
            {
                if (item.BarCode == barcode)
                {
                    return item;
                }
            }

            return null;
        }

        public Item GetByName(string name)
        {
            foreach (Item item in ProductList)
            {
                if (item.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
            }

            return null;
        }
        
        public List<Item> GetAll ()
        {
            return ProductList;
        }
    }
}