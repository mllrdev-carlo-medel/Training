using System;
namespace ShoppingCart.Business.View.Interfaces
{
    public interface ICartView : IView
    {
        void AddItem(Item item);
        void ChangeQuantity(Item item, int quantity);
        void ShowTotalPrice();
    }
}
