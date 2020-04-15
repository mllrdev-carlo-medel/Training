namespace ShoppingCart.Helper
{
    public static class StringExtensions
    {
        public static int ToInt(this string input, int defaultValue = 0)
        {
            return int.TryParse(input, out int value) ? value : defaultValue;
        }
    }
}
