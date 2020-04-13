using System;
using System.Collections.Generic;
using ShoppingCart.Business.Enums;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Manager.Interfaces;
using ShoppingCart.Business.View.Interfaces;

namespace ShoppingCart.Business.View
{
    public class CartView : ICartView
    {
        public IManager Cart { get; }

        public CartView()
        {
            Cart = new CartManager();
        }
        
        public void AddItem(Item item)
        {
            if (((CartManager)Cart).AddItem(item) == RetVal.SUCCESS)
            {
                Console.WriteLine($"Item {item.Name} succesfully added");
            }
            else
            {
                Console.WriteLine($"Item can't be found");
            }
        }

        public void ChangeQuantity(Item item, int quantity)
        {
            if (((CartManager)Cart).ChangeQuantity(item, quantity) == RetVal.SUCCESS)
            {
                Console.WriteLine($"Item {item.Name} quantity changed succesfully");
            }
            else
            {
                Console.WriteLine("Item quantity can't be changed");
            }
        }

        public void ShowItems()
        {
            List<Item> items = Cart.GetAll();

            int count = 1;

            if (items.Count > 0)
            {
                foreach (Item item in items)
                {
                    Console.WriteLine($"{count++}. Name: {item.Name}, Barcode: {item.BarCode}," +
                                      $" Price: {item.Price}, Quantity: {item.Quantity}");
                }
            }
            else
            {
                Console.WriteLine("Your cart is empty");
            }
        }

        public void ShowTotalPrice()
        {
            Console.WriteLine($"Total Price is {((CartManager)Cart).ComputeTotalPrice()}");
            Console.WriteLine("Thank you! Please come again.");
        }
    }
}