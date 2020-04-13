using System;
using System.Collections.Generic;
using ShoppingCart.Business;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Repository;
using ShoppingCart.Business.Enums;
using ShoppingCart.Business.View;
using ShoppingCart.Business.View.Interfaces;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            IView groceriesView = new GroceriesView();
            IView cartView = new CartView();

            Console.WriteLine ("Welcome! Slect the items you want to add in your cart");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Press 1 to add items, 2 to change the quantity of an item, " +
                                  "3 to show your cart, and 4 to check out.");
                groceriesView.ShowItems();
                Console.WriteLine();

                int input;

                /* debug */
                Console.WriteLine($"cmedel cart: {CartRepository.objectCount} groceries {GroceriesRepository.objectCount}");

                input = GetInt(Console.ReadLine());
                Console.Clear();

                Actions action = (Actions)input;

                if (action == Actions.ADD_ITEM)
                {
                    Console.WriteLine("Enter the name of the item");
                    Item item = ((GroceriesView)groceriesView).Groceries.GetByName(Console.ReadLine());

                    ((CartView)cartView).AddItem(item);
                }
                else if (action == Actions.CHANGE_QUANTITY_OF_ITEM)
                {
                    Console.WriteLine("Enter the name of the item");
                    string name = Console.ReadLine();
                    Item item = ((CartView)cartView).Cart.GetByName(name);

                    if (item != null)
                    {
                        Console.WriteLine("Enter the new quantity of the item");
                        int quantity = GetInt(Console.ReadLine());

                        if (quantity == (int)RetVal.ERROR)
                        {
                            Console.WriteLine("Can't change quantity for that value");
                        }
                        else
                        {
                            ((CartView)cartView).ChangeQuantity(((CartView)cartView).Cart.GetByName(name), quantity);

                            if (quantity == 0)
                            {
                                Console.WriteLine("Item removed completely!");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entered item can't be found!");
                    }
                }
                else if (action == Actions.SHOW_CART)
                {
                    cartView.ShowItems();
                }
                else if (action == Actions.CHECK_OUT)
                {
                    ((CartView)cartView).ShowTotalPrice();
                    break;
                }
                else
                {
                    Console.WriteLine("Action not recognize. Try again.");
                }
            }
        }

        static int GetInt(string input)
        {
            int value;

            try
            {
                value = Convert.ToInt32(input);
            }
            catch (Exception)
            {
                return (int)RetVal.ERROR;
            }

            return value;
        }
    }
}
