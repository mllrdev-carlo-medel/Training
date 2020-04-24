using System;
using log4net;
using log4net.Config;
using ShoppingCart.Business;
using ShoppingCart.Business.Enums;
using ShoppingCart.Business.View;
using ShoppingCart.View.Interfaces;
using ShoppingCart.Helper;
using ShoppingCart.Business.Model;

using ShoppingCart.View;
using ShoppingCart.Business.Entity;
using System.Collections.Generic;
using System.Transactions;
using ShoppingCart.Business.Log;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            IView customerList = new CustomerListView();
            IView customerView = null;
            
            while (customerView == null)
            {
                customerList.Show();
                Console.WriteLine("\nAre you a new customer?\nPress 1 if yes, otherwise press 2.");
                int response = Console.ReadLine().ToInt(-1);
                Console.Clear();

                if (response == 1)
                {
                    Customer customer = new Customer();

                    customer.Id = GenerateID.GetGeneratedID();
                    Console.WriteLine("Enter your first name:");
                    customer.FirstName = Console.ReadLine();
                    Console.WriteLine("Enter your Middle name:");
                    customer.MiddleName = Console.ReadLine();
                    Console.WriteLine("Enter your Last name:");
                    customer.LastName = Console.ReadLine();
                    Console.WriteLine("Enter your gender 'M' - Male, 'F' - Female:");
                    customer.Gender = Console.ReadLine();
                    Console.WriteLine("Enter your contact no.");
                    customer.ContactNo = Console.ReadLine();
                    Console.WriteLine("Enter your email address:");
                    customer.Email = Console.ReadLine();
                    Console.WriteLine("Enter your current address");
                    customer.Address = Console.ReadLine();

                    customerView = new CustomerView(customer);

                    if (((CustomerView)customerView).CustomerManager.Add(customer))
                    {
                        Console.WriteLine("Member succesfully added! See details below.");
                        customerView.Show();
                    }
                    else
                    {
                        Console.WriteLine("Member can't be added.");
                        customerView = null;
                    }
                }
                else if (response == 2)
                {
                    Console.WriteLine("Enter your Id.");
                    Customer customer = ((CustomerListView)customerList).Manager.GetById(Console.ReadLine().ToInt(-1), "Id");
                    if (customer == null)
                    {
                        Console.WriteLine($"Entered Id can't be found!");
                    }
                    else
                    {
                        customerView = new CustomerView(customer);
                    }
                }
                else
                {
                    Console.WriteLine("Response not recognize. Please try again.");
                }
            }

            while (true)
            {
                Console.WriteLine($"\nHello {((CustomerView)customerView).Customer.Info.FirstName}! What would you like to do?");
                Console.WriteLine("Press 1 to show your order history. Press 2 to shop! Press 3 to exit.\n");
                int response = Console.ReadLine().ToInt(-1);

                Console.Clear();

                if(response == 1)
                {
                    customerView.Show();
                }
                else if (response == 2)
                {
                    IView cartView = null;
                    bool doneShopping = false;
                    PurchaseHistory purchaseHistory = ((CustomerView)customerView).Customer.PurchaseHistory.Find(x => x.Purchase.Status == "Pending");
                    Purchase purchase;

                    if(purchaseHistory == null)
                    {
                        purchase = new Purchase(GenerateID.GetGeneratedID(), ((CustomerView)customerView).Customer.Info.Id,
                                                "Pending", DateTime.Now.ToString(), 0);

                        if (((CustomerView)customerView).PurchaseManager.Add(purchase))
                        {
                            Console.WriteLine("New purchase. Add items to your cart.");
                            ((CustomerView)customerView).Customer.PurchaseHistory.Add(new PurchaseHistory(purchase));
                            cartView = new CartView(new List<PurchaseDetails>(), purchase.Id);
                        }
                        else
                        {
                            Console.WriteLine("Can't create new purchase. Please try again.");
                            doneShopping = true;
                        }  
                    }
                    else
                    {
                        purchase = purchaseHistory.Purchase;
                        Console.WriteLine("You have a pending purchase. Restoring.");
                        cartView = new CartView(purchaseHistory.PurchaseDetails, purchaseHistory.Purchase.Id);
                    }
    
                    IView groceriesView = new GroceriesView();
                
                    while (!doneShopping)
                    {
                        Console.WriteLine("Press 1 to add an item, 2 to change the quantity of an item, " +
                                          "3 to show your cart, and 4 to check out, 5 to exit.\n");
                        groceriesView.Show();
                        Console.WriteLine();

                        int input;

                        input = Console.ReadLine().ToInt(0);
                        Actions action = (Actions)input;

                        Console.Clear();

                        switch (action)
                        {
                            case Actions.ADD_ITEM:
                                {
                                    Console.WriteLine("Enter the barcode of an item");
                                    Item item = ((GroceriesView)groceriesView).Manager.GetById(Console.ReadLine().ToInt(-1), "Id");

                                    if (item == null)
                                    {
                                        Console.WriteLine("Item can't be found.");
                                    }
                                    else
                                    {
                                        ((CartView)cartView).AddItem(item);
                                    }

                                    break;
                                }
                            case Actions.CHANGE_QUANTITY:
                                {
                                    Console.WriteLine("Enter the barcode of an item to change quantity.");
                                    int id = Console.ReadLine().ToInt(-1);

                                    Item item = null;

                                    try
                                    {
                                        item = ((CartView)cartView).Purchases.Find(x => x.PurchaseItem.ItemId == id).Item;
                                    }
                                    catch (Exception ex)
                                    {
                                        Logging.log.Error(ex);
                                    }

                                    if (item != null)
                                    {
                                        Console.WriteLine("Enter the new quantity of the item");
                                        int quantity = Console.ReadLine().ToInt(-1);

                                        if (quantity == -1)
                                        {
                                            Console.WriteLine("Can't change quantity for that value");
                                        }
                                        else
                                        {
                                            ((CartView)cartView).ChangeQuantity(item, quantity);
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
                                    cartView.Show();
                                    break;
                                }
                            case Actions.CHECK_OUT:
                                {
                                    using (TransactionScope scope = new TransactionScope())
                                    {
                                        float total = ((CartView)cartView).ComputeTotalPrice();
                                        purchase.Status = "Purchased";
                                        purchase.Date = DateTime.Now.ToString();
                                        purchase.Total = total;

                                        if (((CustomerView)customerView).PurchaseManager.Update(purchase))
                                        {
                                            Console.WriteLine("Thank you. Please come again.");
                                            doneShopping = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Can't proceed to check out. Please try again.");
                                            break;
                                        }

                                        scope.Complete();
                                    }

                                    break;
                                }
                            case Actions.EXIT:
                                {
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
                else if (response == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Response not recognize. Please try again.");
                }
            }
        }
    }
}
