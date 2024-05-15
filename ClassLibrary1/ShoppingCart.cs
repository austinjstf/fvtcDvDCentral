using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AJS.DVDCentral.BL.Models
{
    public class ShoppingCart
    {
        public List<Movie> Movies { get; set; } = new List<Movie>();

        public int NumberOfItems { get { return Movies.Count; } }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double SubTotal { get { return Movies.Count * (1); } } // this value is wrong / hard coded in for now. // reminder

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Tax { get { return SubTotal * .055; } }


        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Total { get { return SubTotal + Tax; } }

        public Guid CustomerId { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<object> Items { get; set; }
    }
}
