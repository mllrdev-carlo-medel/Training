using System.Collections.Generic;
using ShoppingCart.Business.Manager.Interfaces;
using ShoppingCart.Business.Repository.Interfaces;

namespace ShoppingCart.Business.Manager
{
    public abstract class BaseManager
    {
        public abstract IRepository ProductRepository { get; }
        
        public List<Item> GetAll ()
        {
            return ProductRepository.GetAll();
        }

        public Item GetByName (string name)
        {
            return ProductRepository.GetByName(name);
        }

        public Item GetByBarcode (int barcode)
        {
            return ProductRepository.GetByBarcode(barcode);
        }
    }
}
