using System;
using System.Collections.Generic;
using ShoppingCart.Business.Manager.Interfaces;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.View.Interfaces;

namespace ShoppingCart.Business.View
{
    public class GroceriesView : IGroceriesView
    {
        public IManager Groceries { get; }

        public GroceriesView()
        {
            Groceries = new GroceriesManager();
        }
        
        public void ShowItems()
        {
            List<Item> items = Groceries.GetAll();

            foreach (Item item in items)
            {
                Console.WriteLine($"Name: {item.Name}, Barcode: {item.BarCode}," +
                                  $" Price: {item.Price}");
            }
        }
    }
}
