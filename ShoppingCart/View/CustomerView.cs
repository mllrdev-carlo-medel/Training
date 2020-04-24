using System;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Model;
using ShoppingCart.Business.Entity;
using System.Collections.Generic;
using ShoppingCart.Business.Manager.Interfaces;
using ShoppingCart.View.Interfaces;

using ShoppingCart.Business.Repository;

namespace ShoppingCart.View
{
    public class CustomerView : ICustomerView
    {
        public CustomerDetails Customer { get; }

        public IManager<Customer> CustomerManager { get; } = new CustomerManager();
        public IManager<Item> ItemManager { get; } = new ItemManager();
        public IManager<PurchaseItem> PurchaseItemManager { get; } = new PurchaseItemManager();
        public IManager<Purchase> PurchaseManager { get; } = new PurchaseManager();

        public CustomerView (Customer customer)
        {
            Customer = new CustomerDetails(customer);

           LoadData();
        }

        public void Show()
        {
            LoadData();

            Console.WriteLine($"Name:{Customer.Info.FirstName} {Customer.Info.MiddleName} {Customer.Info.LastName}\n" +
                              $"{Customer.Info.Gender}, {Customer.Info.ContactNo}, {Customer.Info.Email}, {Customer.Info.Address}\n");

            if (Customer.PurchaseHistory.Count > 0)
            {
                foreach (PurchaseHistory purchaseHistory in Customer.PurchaseHistory)
                {
                    Console.WriteLine($"Purchase Status: {purchaseHistory.Purchase.Status}");
                    Console.WriteLine($"Purchase Date: {purchaseHistory.Purchase.Date}");
                    Console.WriteLine($"Total: {purchaseHistory.Purchase.Total}");

                    foreach (PurchaseDetails purchaseDetails in purchaseHistory.PurchaseDetails)
                    {
                        int count = 1;
                        Console.WriteLine($"\t{count++}. Name:{purchaseDetails.Item.Name}, Id:{purchaseDetails.Item.Id}, " +
                                          $"Qty:{purchaseDetails.PurchaseItem.Quantity}, Price:{purchaseDetails.Item.Price}, " +
                                          $"Subtotal: {purchaseDetails.PurchaseItem.SubTotal}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Empty! Shop now!");
            }
        }

        public void LoadData()
        {
            Customer.PurchaseHistory.Clear();

            foreach (Purchase purchase in PurchaseManager.GetAllById(Customer.Info.Id, "CustomerId"))
            {
                Customer.PurchaseHistory.Add(new PurchaseHistory(purchase));
            }

            foreach (PurchaseHistory purchaseHistory in Customer.PurchaseHistory)
            {
                foreach (PurchaseItem purchaseItem in PurchaseItemManager.GetAllById(purchaseHistory.Purchase.Id, "PurchaseId"))
                {
                    purchaseHistory.PurchaseDetails.Add(new PurchaseDetails(purchaseItem, ItemManager.GetById(purchaseItem.ItemId, "Id")));
                }
            }
        }
    }
}
