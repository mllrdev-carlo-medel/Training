using ShoppingCart.Business.Enums;
namespace ShoppingCart.Business.Repository.Interfaces
{
    public interface ICartRepository : IRepository
    {
        RetVal AddItem(Item item);
        RetVal ChangeQuantity(Item item, int quantity);
        double ComputeTotalPrice();
    }
}
