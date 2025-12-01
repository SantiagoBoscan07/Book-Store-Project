using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    internal class ShoppingCart
    {
        // Setters and getters for ShoppingCart properties
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
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
        public void AddItem(OrderItem item)
        {
            var existing = Items.FirstOrDefault(i => i.BookID == item.BookID);
            if (existing != null)
            {
                existing.Quantity += item.Quantity;
            }
            else
            {
                OrderItem cart = new OrderItem();
                cart.BookID = item.BookID;
                cart.Quantity = item.Quantity;
                cart.Price = item.Price;
                Items.Add(cart);
            }

            CalculateTotals();
        }

        //Remove Item
        public void RemoveItem(OrderItem cart)
        {
            var item = Items.FirstOrDefault(i => i.BookID == cart.BookID);
            if (item != null)
            {
                Items.Remove(item);
            }

            CalculateTotals();
        }

        //Update Item
        public void UpdateItem(OrderItem cart)
        {
            var item = Items.FirstOrDefault(i => i.BookID == cart.BookID);
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

        //Commit Order
        public void CommitOrder() //to be implemented when integrading
        {
            //Generate order number
            //Add all order items to invoice
            //Return oreder number
        }
    }
}
