using System;
using GroceryStore;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            Groceries groceries = new Groceries();
            Cart myCart = new Cart();

            Console.WriteLine ("Welcome! Slect the items you want to add in your cart");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Press 1 to add items, 2 to change the quantity of an item," +
                                  "3 to show your cart, and 4 to check out.");
                groceries.ShowGroceries();
                Console.WriteLine();

                int input;

                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                }
                catch (Exception)
                {
                    input = 0;
                }

                Actions action = (Actions)input;

                if (action == Actions.ADD_ITEM)
                {
                    Console.WriteLine("Enter the name of the item");
                    Item item = groceries.GetItemByName(Console.ReadLine());
                    if (item != null)
                    {
                        myCart.AddItem(item);
                        Console.WriteLine($"Added Item {item.Name}");
                    }
                    else
                    {
                        Console.WriteLine("Entered item can't be found!");
                    }

                }
                else if (action == Actions.CHANGE_QUANTITY_OF_ITEM)
                {
                    Console.WriteLine("Enter the name of the item");
                    string name = Console.ReadLine();
                    Item item = myCart.GetItemByName(name);

                    if (item != null)
                    {
                        Console.WriteLine("Enter the new quantity of the item");

                        try
                        {
                            int quantity = Convert.ToInt32(Console.ReadLine());
                            myCart.ChangeQuantity(myCart.GetItemByName(name), quantity);

                            if (quantity == 0)
                            {
                                Console.WriteLine("Item removed completely!");
                            }

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Can't change the quantity for that value");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entered item can't be found!");
                    }
                }
                else if (action == Actions.SHOW_CART)
                {
                    myCart.ShowGroceries();
                }
                else if (action == Actions.CHECK_OUT)
                {
                    double totalPrice = myCart.GetTotalPrice();

                    if (totalPrice == 0.0)
                    {
                        Console.WriteLine("Your cart is empty.");
                    }
                    else
                    {
                        Console.WriteLine("Total Price is Php {0}", totalPrice);
                    }

                    Console.WriteLine("Thank you! Please come again.");
                    break;
                }
                else
                {
                    Console.WriteLine("Action not recognize. Try again.");
                }
            }
        }
    }
}
