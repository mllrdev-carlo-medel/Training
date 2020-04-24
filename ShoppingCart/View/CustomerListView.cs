using System;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Model;
using ShoppingCart.Business.Entity;
using System.Collections.Generic;
using ShoppingCart.Business.Manager.Interfaces;
using ShoppingCart.View.Interfaces;

namespace ShoppingCart.View
{
    public class CustomerListView : ICustomerListView
    {
        public IManager<Customer> Manager { get; }

        public CustomerListView()
        {
            Manager = new CustomerManager();
        }

        public void Show()
        {
            List<Customer> customers = Manager.GetAll();

            int count = 1;
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"{count++}. ID: {customer.Id} Name: {customer.FirstName} {customer.MiddleName} {customer.LastName}, " +
                    $"{customer.Gender}, {customer.ContactNo}, {customer.Email}, Address: {customer.Address}");
            }
        }
    }
}
