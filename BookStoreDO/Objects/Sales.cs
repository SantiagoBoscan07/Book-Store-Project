using System;

namespace BookStoreDO
{
    public class Sales
    {
        public string OrderID { get; set; }
        public string StoreID { get; set; }
        public string TitleID { get; set; }
        public string TitleName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }

        public decimal Subtotal
        {
            get { return Quantity * Price; }
        }
    }
}
