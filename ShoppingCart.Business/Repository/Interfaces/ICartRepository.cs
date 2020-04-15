using ShoppingCart.Business.Enums;
namespace ShoppingCart.Business.Repository.Interfaces
{
    public interface ICartRepository : IRepository
    {
        bool AddItem(Item item);
        bool ChangeQuantity(Item item, int quantity);
        double ComputeTotalPrice();
    }
}
