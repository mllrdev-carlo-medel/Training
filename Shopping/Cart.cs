using System;
using System.Collections.Generic;

namespace Shopping
{
    public class Cart : Groceries, IAddItem, IChangeQuantity
    {
        private List<int> itemCount = new List<int>();

        public Cart()
        { }

        public override void ShowGroceries()
        {
            if (GroceryLists.Count > 0)
            {
                Console.WriteLine("Items in cart:");
                int count = 0;
                foreach (Item i in GroceryLists)
                {
                    Console.WriteLine("{0}. Name: {1}, BarCode: {2}, Price: {3} Qty: {4}",
                                      count+1, i.Name, i.BarCode, i.Price, itemCount[count]);
                    count++;
                }
            }
            else
            {
                Console.WriteLine("Your cart is empty");
            }
        }

        public void AddItem(Item item)
        {
            if (item == null)
                return;

            int index = 0;
            foreach (Item i in GroceryLists)
            {
                if (i.BarCode == item.BarCode)
                {
                    itemCount[index]++;
                    Console.WriteLine("Added item {0}, current count is: {1}", item.Name, itemCount[index]);
                    return;
                }
                index++;
            }

            GroceryLists.Add(item);
            itemCount.Add(1);
            Console.WriteLine("Added item {0}", item.Name);
        }

        public double TotalPrice()
        {
            int index = 0;
            double totalPrice = 0.0;

            if (GroceryLists.Count == 0)
            {
                Console.WriteLine("No items in cart");
                return totalPrice;
            }

            
            foreach (Item i in GroceryLists)
            {
                totalPrice += (i.Price * itemCount[index]);
                index++;
            }

            return totalPrice;
        }

        public void ChangeQuantity(Item item, int qty)
        {
            if (item == null)
                return;

            int index = 0;
            foreach (Item i in GroceryLists)
            {
                if (i.BarCode == item.BarCode)
                {
                    if (qty == 0)
                    {
                        itemCount.RemoveAt(index);
                        GroceryLists.RemoveAt(index);
                        Console.WriteLine("Item removed completely!");
                        return;
                    }
                    else
                    {
                        itemCount[index] = qty;
                        return;
                    }
                }
                index++;
            }
        }
    }
}
