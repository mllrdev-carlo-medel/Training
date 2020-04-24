using System;
using ShoppingCart.Business.Repository;
using ShoppingCart.Business.Entity;
using ShoppingCart.Business.Repository.Interfaces;
using ShoppingCart.Business.Manager.Interfaces;

namespace ShoppingCart.Business.Manager
{
    public class ItemManager : BaseManager<Item>, IItemManager
    {
        public override IRepository<Item> Repository => new ItemRepository();
    }
}
