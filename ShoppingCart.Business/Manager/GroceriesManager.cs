using ShoppingCart.Business.Repository.Interfaces;
using ShoppingCart.Business.Manager.Interfaces;

namespace ShoppingCart.Business.Manager
{
    public class GroceriesManager : ProductsManager, IGroceriesManager
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

        public GroceriesManager ()
        {
            ProductRepository = new GroceriesRepository();
        }
    }
}
