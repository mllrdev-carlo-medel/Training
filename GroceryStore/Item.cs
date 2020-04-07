namespace GroceryStore
{
    public class Item
    {
        public string Name { get; set; }
        public int BarCode { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Item(string name = "No name",
                   int barcode = 0,
                   double price = 0.0,
                   int quantity = 0)
        {
            Name = name;
            BarCode = barcode;
            Price = price;
            Quantity = quantity;
        }
    }
}
