using ShoppingCart.Business.Enums;
namespace ShoppingCart.Business.Manager.Interfaces
{
   public interface ICartManager : IManager
    {
        bool AddItem(Item item);
        bool ChangeQuantity(Item item, int quantity);
        double ComputeTotalPrice();
    }
}
