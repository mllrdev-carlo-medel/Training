using System;
using GroceryStore;

namespace Shopping
{
    public class Cart : Products, IItemActions
    {

        public override void ShowGroceries()
        {
            if (GroceryLists.Count > 0)
            {
                Console.WriteLine("Items in cart:");
                int count = 1;

                foreach (Item item in GroceryLists)
                {
                    Console.WriteLine($"{count++}. Name: {item.Name}, BarCode: {item.BarCode}, " +
                                      $"Price: {item.Price} Quantity: {item.Quantity}");    
                }
            }
            else
            {
                Console.WriteLine("Your cart is empty");
            }
        }

        public void AddItem(Item item)
        {
            if (item != null)
            {
                foreach (Item groceryItem in GroceryLists)
                {
                    if (groceryItem.BarCode == item.BarCode)
                    {
                        groceryItem.Quantity++;
                        return;
                    }
                }

                GroceryLists.Add(new Item(item.Name, item.BarCode, item.Price, 1));
            }
        }

        public void ChangeQuantity(Item item, int quantity)
        {
            if (item != null)
            {
                int index = 0;

                foreach (Item groceryItem in GroceryLists)
                {
                    if (groceryItem.BarCode == item.BarCode)
                    {
                        if (quantity == 0)
                        {
                            GroceryLists.RemoveAt(index);
                            return;
                        }
                        else
                        {
                            groceryItem.Quantity = quantity;
                            return;
                        }
                    }

                    index++;
                }
            }
        }

        public double GetTotalPrice()
        {
            double totalPrice = 0.0;

            if (GroceryLists.Count == 0)
            {
                return totalPrice;
            }
            
            foreach (Item item in GroceryLists)
            {
                totalPrice += (item.Price * item.Quantity);
            }

            return totalPrice;
        }
    }
}
