using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJS.DVDCentral.BL.Models
{
    public class Director
    {
        public Guid Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; } = string.Empty;
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
