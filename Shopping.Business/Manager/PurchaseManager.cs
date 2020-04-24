using ShoppingCart.Business.Repository;
using ShoppingCart.Business.Entity;
using ShoppingCart.Business.Repository.Interfaces;
using ShoppingCart.Business.Manager.Interfaces;

namespace ShoppingCart.Business.Manager
{
    public class PurchaseManager : BaseManager<Purchase>, IPurchaseManager
    {
        public override IRepository<Purchase> Repository => new PurchaseRepository();
    }
}
