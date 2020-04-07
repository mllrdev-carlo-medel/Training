using System;
namespace Shopping
{
    interface IGetItemByBarcode
    {
        Item GetItemByBarCode(int barcode);
    }
}
