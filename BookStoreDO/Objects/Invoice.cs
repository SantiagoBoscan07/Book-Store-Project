namespace BookStoreDO
{
    public class Invoice
    {
        // Properties representing invoice details
        public string OrderID { get; set; }
        public string StoreID { get; set; }
        public DateTime OrderDate { get; set; }
        public short Quantity { get; set; }
        public string TitleID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; } 
        public decimal ExtendedPrice => Quantity * Price; 
    }
}

