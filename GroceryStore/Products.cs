using System;
using System.Collections.Generic;


namespace GroceryStore
{
    public abstract class Products : IGetItem
    {

        protected List<Item> GroceryLists = new List<Item>();

        public Item GetItemByBarcode(int barcode)
        {
            foreach (Item i in GroceryLists)
            {
                if (i.BarCode == barcode)
                    return i;
            }

            return null;
        }

        public Item GetItemByName(string name)
        {
            foreach (Item i in GroceryLists)
            {
                if (i.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return i;
            }

            return null;
        }

        public abstract void ShowGroceries();
    }
}
