using ShoppingCart.Business.Enums;
using ShoppingCart.Business.Manager.Interfaces;
using ShoppingCart.Business.Repository.Interfaces;

namespace ShoppingCart.Business.Manager
{
    public class CartManager : ProductsManager, ICartManager
    {
        private IRepository productRepository = null;

        public override IRepository ProductRepository
        {
            get
            {
                return productRepository;
            }
            set
            {
                productRepository = value;
            }
        }

        public CartManager ()
        {
            ProductRepository = new CartRepository ();
        }

        public RetVal AddItem(Item item)
        {
            return item != null ? ((CartRepository)ProductRepository).AddItem(item) : RetVal.ERROR;
        }

        public RetVal ChangeQuantity(Item item, int quantity)
        {
            return item != null ? ((CartRepository)ProductRepository).ChangeQuantity(item, quantity) : RetVal.ERROR;
        }

        public double ComputeTotalPrice()
        {
            return ((CartRepository)ProductRepository).ComputeTotalPrice();
        }
    }
}
