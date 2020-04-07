using GroceryStore;

namespace Shopping
{
    interface IItemActions
    {
        void AddItem(Item item);
        void ChangeQuantity(Item item, int qty);
    }
}
