using System;
namespace ShoppingCart.Business.Entity
{
    public class PurchaseItem
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public float SubTotal { get; set; }

        public PurchaseItem()
        {

        }

        public PurchaseItem (int id, int purchaseId, int itemId, int quantity, float subtotal)
        {
            Id = id;
            PurchaseId = purchaseId;
            ItemId = itemId;
            Quantity = quantity;
            SubTotal = subtotal;
        }
    }
}
