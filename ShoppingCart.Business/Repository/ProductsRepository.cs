using System;
using System.Collections.Generic;


namespace ShoppingCart.Business
{
    public abstract class ProductsRepository
    {
        protected List<Item> GroceryList = new List<Item>();

        public Item GetByBarcode(int barcode)
        {
            foreach (Item item in GroceryList)
            {
                if (item.BarCode == barcode)
                    return item;
            }

            return null;
        }

        public Item GetByName(string name)
        {
            foreach (Item item in GroceryList)
            {
                if (item.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return item;
            }

            return null;
        }

        public List<Item> GetAll ()
        {
            return GroceryList;
        }
    }
}
