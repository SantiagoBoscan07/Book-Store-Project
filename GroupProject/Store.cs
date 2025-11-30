using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    public class Store
    {
        // Properties for store object
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string StoreCity { get; set; }
        public string StoreState { get; set; }
        public string StoreZip { get; set; }

        // Constructor
        public Store() { }

        // Overloaded constructor
        public Store(int id, string name, string address, string city, string state, string zip)
        {
            StoreID = id;
            StoreName = name;
            StoreAddress = address;
            StoreCity = city;
            StoreState = state;
            StoreZip = zip;
        }

        // Override ToString method for easy display
        public override string ToString()
        {
            return $"{StoreID} - {StoreName}";
        }
    }
}
