using ShoppingCart.Business.Enums;
using ShoppingCart.Business.Manager.Interfaces;
using ShoppingCart.Business.Repository.Interfaces;

namespace ShoppingCart.Business.Manager
{
    public class CartManager : BaseManager, ICartManager
    {
       public override IRepository ProductRepository => new CartRepository();

        public bool AddItem(Item item)
        {
            return item != null ? ((CartRepository)ProductRepository).AddItem(item) : false;
        }

        public bool ChangeQuantity(Item item, int quantity)
        {
            return item != null ? ((CartRepository)ProductRepository).ChangeQuantity(item, quantity) : false;
        }

        public double ComputeTotalPrice()
        {
            return ((CartRepository)ProductRepository).ComputeTotalPrice();
        }
    }
}
