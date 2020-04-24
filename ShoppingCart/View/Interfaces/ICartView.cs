using ShoppingCart.Business.Entity;

namespace ShoppingCart.View.Interfaces
{
    public interface ICartView : IView
    {
        void AddItem(Item item);
        void ChangeQuantity(Item item, int quantity);
        float ComputeTotalPrice();
    }
}
