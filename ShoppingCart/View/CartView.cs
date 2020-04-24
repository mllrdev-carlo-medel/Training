using System;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Model;
using ShoppingCart.Business.Entity;
using System.Collections.Generic;
using ShoppingCart.Business.Manager.Interfaces;
using ShoppingCart.View.Interfaces;
using System.Linq;
using System.Transactions;
using ShoppingCart.Helper;
using ShoppingCart.Business.Log;

namespace ShoppingCart.Business.View
{
    public class CartView : ICartView
    {
        public int PurchaseId { get; set; }
        public List<PurchaseDetails> Purchases { get; }
        public IManager<Item> ItemManager { get; } = new ItemManager();
        public IManager<PurchaseItem> PurchaseItemManager { get; } = new PurchaseItemManager();

        public CartView(List<PurchaseDetails> purchaseDetails, int id)
        {
            Purchases = purchaseDetails;
            PurchaseId = id;
        }

        public void Show()
        {
            if (Purchases.Count > 0)
            {
                Console.WriteLine("Items in your cart:");
                int count = 1;
                foreach (PurchaseDetails purchase in Purchases)
                {
                    Console.WriteLine($"{count++}. Name:{purchase.Item.Name}, Id:{purchase.Item.Id}, " +
                                      $"Qty:{purchase.PurchaseItem.Quantity}, Price:{purchase.Item.Price}, " +
                                      $"Subtotal: {purchase.PurchaseItem.SubTotal}");
                }
            }
            else
            {
                Console.WriteLine("Your cart is empty!");
            }
        }

        public void AddItem(Item item)
        {

            PurchaseDetails purchaseDetails = null;

            try
            {
                purchaseDetails = Purchases.Find(x => x.Item.Id == item.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error looking for the same item\n");
                Logging.log.Error(ex);
            }

            if (purchaseDetails != null)
            {
                purchaseDetails.PurchaseItem.Quantity += 1;
                purchaseDetails.PurchaseItem.SubTotal = purchaseDetails.PurchaseItem.Quantity * item.Price;

                if (PurchaseItemManager.Update(purchaseDetails.PurchaseItem))
                {
                    Console.WriteLine("Item Successfully added.");
                }
                else
                {
                    Console.WriteLine("Item not added! Please try again.");
                }
            }
            else
            {
                PurchaseItem purchaseItem = new PurchaseItem(GenerateID.GetGeneratedID(), PurchaseId, item.Id, 1, item.Price);
                
                if (PurchaseItemManager.Add(purchaseItem))
                {
                    Purchases.Add(new PurchaseDetails(purchaseItem, item));
                    Console.WriteLine("Item successfully added.");
                }
                else
                {
                    Console.WriteLine("Item not added! Please try again.");
                }
            }
        }

        public void ChangeQuantity(Item item, int quantity)
        {
            int index = Purchases.FindIndex(x => x.PurchaseItem.ItemId == item.Id);

            if (index == -1)
            {
                Console.WriteLine($"Item {item.Name} can't be found");           
            }
            else
            {
                if (quantity == 0)
                {
                    int[] ids = { Purchases[index].PurchaseItem.Id };

                    if (PurchaseItemManager.Delete(ids, "Id"))
                    {
                        Purchases.RemoveAt(index);
                        Console.WriteLine("Item remove completely.");
                    }
                    else
                    {
                        Console.WriteLine("Item can't be removed!");
                    }
                }
                else
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        Purchases[index].PurchaseItem.Quantity = quantity;
                        Purchases[index].PurchaseItem.SubTotal = quantity * item.Price;

                        if (PurchaseItemManager.Update(Purchases[index].PurchaseItem))
                        {
                            Console.WriteLine("Item quantity change successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Item quantity can't be change.");
                            return;
                        }

                        scope.Complete();
                    }
                }
            }
        }

        public float ComputeTotalPrice()
        {
            float total = Purchases.Sum(x => x.PurchaseItem.SubTotal);
            Console.WriteLine($"Total Price is Php{total}");
            return total;
        }
    }
}