using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJS.DVDCentral.BL.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; } = string.Empty;
        [DisplayName("Last Name")]
        public string LastName { get; set; } = string.Empty;

        [DisplayName("Customer Name")]
        public string Fullname { get { return FirstName + " " + LastName; } }

        public Guid UserId { get; set;}
        public string Address { get; set; } 
        public string City { get; set; }
        public string State { get; set;}
        public string ZIP { get; set; }
        public string Phone { get; set;}
    }
}
