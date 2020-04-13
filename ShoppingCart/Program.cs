using System;
using ShoppingCart.Business;
using ShoppingCart.Business.Enums;
using ShoppingCart.Business.View;
using ShoppingCart.Business.View.Interfaces;
using ShoppingCart.Helper;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            bool doneShopping = false;

            IView groceriesView = new GroceriesView();
            IView cartView = new CartView();

            Console.WriteLine ("Welcome! Select the items you want to add in your cart\n");

            while (!doneShopping)
            {
                Console.WriteLine("Press 1 to add an item, 2 to change the quantity of an item, " +
                                  "3 to show your cart, and 4 to check out.\n");
                groceriesView.ShowItems();
                Console.WriteLine();

                int input;

                input = HelperClass.GetInt(Console.ReadLine());
                Actions action = (Actions)input;

                Console.Clear();

                switch (action)
                {
                    case Actions.ADD_ITEM:
                    {
                        Console.WriteLine("Enter the name of the item");
                        Item item = ((GroceriesView)groceriesView).Groceries.GetByName(Console.ReadLine());
                        ((CartView)cartView).AddItem(item);
                        break;
                    }
                    case Actions.CHANGE_QUANTITY_OF_ITEM:
                    {
                        Console.WriteLine("Enter the name of the item");
                        string name = Console.ReadLine();
                        Item item = ((CartView)cartView).Cart.GetByName(name);

                        if (item != null)
                        {
                            Console.WriteLine("Enter the new quantity of the item");
                            int quantity = HelperClass.GetInt(Console.ReadLine());

                            if (quantity == (int)RetVal.ERROR)
                            {
                                Console.WriteLine("Can't change quantity for that value");
                            }
                            else
                            {
                                ((CartView)cartView).ChangeQuantity(item, quantity);

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

                        break;
                    }
                    case Actions.SHOW_CART:
                    {
                        cartView.ShowItems();
                        break;
                    }
                    case Actions.CHECK_OUT:
                    {
                        ((CartView)cartView).ShowTotalPrice();
                        doneShopping = true;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Action not recognize. Try again.");
                        break;
                    }
                }
            }
        }
    }
}
