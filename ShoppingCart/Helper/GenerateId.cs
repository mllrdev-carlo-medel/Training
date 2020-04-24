using System;
namespace ShoppingCart.Helper
{
    public static class GenerateID
    {
        public static int GetGeneratedID()
        {
            Guid guid = Guid.NewGuid();
            return Math.Abs(guid.GetHashCode());
        }
    }
}
