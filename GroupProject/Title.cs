using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    internal class Title
    {
        // Setters and getters for Title properties
        public string TitleID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string PublisherID { get; set; }
        public decimal? Price { get; set; }
        public string Notes { get; set; }
        public DateTime PublishedDate { get; set; }

        // Constructor to assign default values to title object
        public Title()
        {
            Type = "UNDECIDED";
            PublishedDate = DateTime.Now;
        }

        // Constructor to assign default values when key fields are provided
        public Title(string titleID, string name)
        {
            TitleID = titleID;
            Name = name;
            Type = "UNDECIDED";
            PublishedDate = DateTime.Now;
        }


    }
}
