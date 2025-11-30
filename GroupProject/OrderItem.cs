namespace GroupProject
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int BookID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal ExtendedPrice => Quantity * Price;
    }
}

