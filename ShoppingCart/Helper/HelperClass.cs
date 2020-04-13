using System;
using ShoppingCart.Business.Enums;
namespace ShoppingCart.Helper
{
    public class HelperClass
    {
        public static int GetInt(string input)
        {
            int value;

            try
            {
                value = Convert.ToInt32(input);
                if (value < 0)
                {
                    return (int)RetVal.ERROR;
                }
            }
            catch (Exception)
            {
                return (int)RetVal.ERROR;
            }

            return value;
        }
    }
}
