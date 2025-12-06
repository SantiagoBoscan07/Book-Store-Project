using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDO
{
    public class ShoppingCart
    {
        // Setters and getters for ShoppingCart properties
        public List<Sales> Items { get; set; } = new List<Sales>();
        private const decimal TaxRate = 0.06m;
        public decimal Subtotal { get; set; }
        public decimal Tax {  get; set; }
        public decimal Total { get; set; }

        //Calculate totals
        public void CalculateTotals()
        {
            Subtotal = Items.Sum(i => i.Quantity * i.Price);
            Tax = Subtotal * TaxRate;
            Total = Subtotal + Tax;
        }

        //Adding item
        public void AddItem(Sales sale)
        {
            var existing = Items.FirstOrDefault(i => i.TitleID == sale.TitleID);
            if (existing != null)
            {
                existing.Quantity += sale.Quantity;
            }
            else
            {
                Sales cart = new Sales();
                cart.TitleName = sale.TitleName;
                cart.TitleID = sale.TitleID;
                cart.Quantity = (short)sale.Quantity;
                cart.Price = sale.Price;
                Items.Add(cart);
            }

            CalculateTotals();
        }

        //Remove Item
        public void RemoveItem(Sales cart)
        {
            var item = Items.FirstOrDefault(i => i.TitleID == cart.TitleID);
            if (item != null)
            {
                Items.Remove(item);
            }

            CalculateTotals();
        }

        //Update Item
        public void UpdateItem(Sales cart)
        {
            var item = Items.FirstOrDefault(i => i.TitleID == cart.TitleID);
            if (cart.Quantity <= 0)
            {
                Items.Remove(cart);
            }
            else
            {
                item.Quantity = cart.Quantity;
            }

            CalculateTotals();
        }

    }
}
