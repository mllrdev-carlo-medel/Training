using ShoppingCart.Business.Repository;
using ShoppingCart.Business.Entity;
using ShoppingCart.Business.Repository.Interfaces;
using ShoppingCart.Business.Manager.Interfaces;

namespace ShoppingCart.Business.Manager
{
    public class PurchaseItemManager : BaseManager<PurchaseItem>, IPurchaseItemManager
    {
        public override IRepository<PurchaseItem> Repository => new PurchaseItemRepository();
    }
}
