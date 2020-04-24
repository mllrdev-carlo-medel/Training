using System.Collections.Generic;
using ShoppingCart.Business.Entity;
using ShoppingCart.Business.Model;

namespace ShoppingCart.Business.Model
{
    public class CustomerDetails
    {
        public Customer Info { get; }
        public List<PurchaseHistory> PurchaseHistory { get; }


        public CustomerDetails(Customer customer)
        {
            Info = customer;
            PurchaseHistory = new List<PurchaseHistory>();
        }
    }
}
