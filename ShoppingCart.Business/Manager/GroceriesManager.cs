using ShoppingCart.Business.Repository.Interfaces;
using ShoppingCart.Business.Manager.Interfaces;

namespace ShoppingCart.Business.Manager
{
    public class GroceriesManager : ProductsManager, IGroceriesManager
    {
        public override IRepository ProductRepository => new GroceriesRepository();
    }
}
