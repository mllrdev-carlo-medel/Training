using System;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {

            Groceries groceries = new Groceries("/Users/carlomedel/Projects/Shopping/groceries.csv");
            Cart myCart = new Cart();

            Console.WriteLine ("Welcome! Slect the items you want to add in your cart");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Press 1 to add items, 2 to change the qty of an item, 3 to show your cart, and 4 to check out.");
                groceries.ShowGroceries();
                Console.WriteLine();

                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("Enter the name of the item");
                    myCart.AddItem(groceries.GetItemByName(Console.ReadLine()));

                }
                else if (input == "2")
                {
                    Console.WriteLine("Enter the name of the item");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the new quantity of the item");
                    try
                    {
                        int qty = Convert.ToInt32(Console.ReadLine());
                        myCart.ChangeQuantity(myCart.GetItemByName(name), qty);
                    } catch (Exception)
                    {
                        Console.WriteLine("Can't change the quantity for that value");
                    }
                }
                else if (input == "3")
                {
                    myCart.ShowGroceries();
                }
                else if (input == "4")
                {
                    Console.WriteLine("Total Price is Php {0}", myCart.TotalPrice());
                    Console.WriteLine("Thank you! Please come again.");
                    break;
                }
                else
                    Console.WriteLine("ACtion not recognize. Try again.");
            }
        }
    }
}
