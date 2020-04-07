namespace GroceryStore
{
    interface IGetItem
    {
        Item GetItemByName(string name);
        Item GetItemByBarcode(int barcode);
    }
}
