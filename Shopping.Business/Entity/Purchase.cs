using System;
namespace ShoppingCart.Business.Entity
{
    public class Purchase
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        public float Total { get; set; }

        public Purchase()
        {

        }

        public Purchase (int id, int customerId, string status, string date, float total)
        {
            Id = id;
            CustomerId = customerId;
            Status = status;
            Date = date;
            Total = total;
        }
    }
}