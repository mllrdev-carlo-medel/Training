using ShoppingCart.Business.Repository.Interfaces;
using ShoppingCart.Business.Enums;
using System;
using System.Linq;

namespace ShoppingCart.Business
{
    public class CartRepository : ProductsRepository, ICartRepository
    {
        public static int objectCount = 0;

        public CartRepository ()
        {
            objectCount += 1;
        }

        public RetVal AddItem(Item item)
        {
            try
            {
                Item cartItem = GroceryList.FirstOrDefault(x => x.BarCode == item.BarCode);

                if (cartItem == null)
                {
                   GroceryList.Add(new Item(item.Name, item.BarCode, item.Price, 1));
                }
                else
                {
                    cartItem.Quantity += 1;
                }

                return RetVal.SUCCESS;
            }
            catch (Exception)
            {
                return RetVal.ERROR;
            }
        }

        public RetVal ChangeQuantity(Item item, int quantity)
        {
            try
            {
                Item cartItem = GroceryList.FirstOrDefault(x => x.BarCode == item.BarCode);

                if (quantity == 0)
                {
                    GroceryList.Remove(cartItem);
                }
                else
                {
                    cartItem.Quantity = quantity;
                }

                return RetVal.SUCCESS;
            }
            catch (Exception)
            {
                return RetVal.ERROR;
            }
        }

        public double ComputeTotalPrice()
        {
            return GroceryList.Sum(x => x.Price * x.Quantity);
        }
    }
}
