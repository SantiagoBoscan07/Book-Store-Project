using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    internal class Employee
    {
        // Properties for the Employee class
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char MiddleInitial { get; set; }
        public short JobID { get; set; }
        public byte JobLevel { get; set; }
        public string PublisherID { get; set; }
        public DateTime HireDate { get; set; }

        // Default constructor 
        public Employee()
        { 
        EmployeeID = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        MiddleInitial = '\0';
        JobID = 1;
        JobLevel = 10;
        PublisherID = "9952";
        HireDate = DateTime.Now;
        }
    }
}
