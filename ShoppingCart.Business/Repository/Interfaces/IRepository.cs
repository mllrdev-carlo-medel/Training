using System.Collections.Generic;

namespace ShoppingCart.Business.Repository.Interfaces
{
    public interface IRepository
    {
        Item GetByName(string name);
        Item GetByBarcode(int barcode);
        List<Item> GetAll();
     }
}
