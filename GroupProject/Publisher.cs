using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    internal class Publisher
    {
        // Setters and getters for Publisher properties
        public string PublisherID { get; set; }
        public string PublisherName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        // Constructor to assign default values to publisher object
        public Publisher()
        {
            Country = "USA";
        }

        // Constructor to assign default values when key fields are provided
        public Publisher(string publisherID, string name)
        {
            PublisherID = publisherID;
            PublisherName = name;
            Country = "USA";
        }
    }
}
