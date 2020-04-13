using System.Collections.Generic;

namespace ShoppingCart.Business.Manager.Interfaces
{
    public interface IManager
    {
        Item GetByName(string name);
        Item GetByBarcode(int barcode);
        List<Item> GetAll();
    }
}
