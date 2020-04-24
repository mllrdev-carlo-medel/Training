using System;
namespace ShoppingCart.Business.Log
{
    public static class Logging
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}
