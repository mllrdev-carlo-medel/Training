using System;
namespace ShoppingCart.Business.Entity
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public Item ()
        {

        }

        public Item (int id, string name, float price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
