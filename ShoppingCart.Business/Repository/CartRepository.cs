using ShoppingCart.Business.Repository.Interfaces;
using ShoppingCart.Business.Enums;
using System;
using System.Linq;
using ShoppingCart.Business.Data;
using System.Collections.Generic;

namespace ShoppingCart.Business
{
    public class CartRepository : ProductsRepository, ICartRepository
    {
        public override List<Item> ProductList => Database.CartList;

        public RetVal AddItem(Item item)
        {
            try
            {
                Item cartItem = ProductList.FirstOrDefault(x => x.BarCode == item.BarCode);

                if (cartItem == null)
                {
                   ProductList.Add(new Item(item.Name, item.BarCode, item.Price, 1));
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
                Item cartItem = ProductList.FirstOrDefault(x => x.BarCode == item.BarCode);

                if (quantity == 0)
                {
                    ProductList.Remove(cartItem);
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
            return ProductList.Sum(x => x.Price * x.Quantity);
        }
    }
}                                                           
