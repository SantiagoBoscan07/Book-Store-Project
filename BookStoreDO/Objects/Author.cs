using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDO
{
    public class Author
    {
        // Setters and getters for Author properties
        public string AuthorID { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorFirstName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool isContracted { get; set; }

        // Default constructor
        public Author()
        {
            Phone = "UKNOWN";
            isContracted = false;
        }
    }
}
