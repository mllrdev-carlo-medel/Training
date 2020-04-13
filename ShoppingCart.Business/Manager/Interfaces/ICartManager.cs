using ShoppingCart.Business.Enums;
namespace ShoppingCart.Business.Manager.Interfaces
{
   public interface ICartManager : IManager
    {
        RetVal AddItem(Item item);
        RetVal ChangeQuantity(Item item, int quantity);
        double ComputeTotalPrice();
    }
}
