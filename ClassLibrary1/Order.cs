using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJS.DVDCentral.BL.Models
{
    public class Order
    {
        [DisplayName("Order #")]
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid UserId { get; set; }
        public DateTime ShipDate { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Total { get { return OrderItems.Sum(o => o.Cost); } }


        public string CustomerName { get; set; }
        public string UserName {  get; set; }

        public List<ShoppingCart> shoppingList { get; set; } = new List<ShoppingCart>();

        public string ImagePath { get; set; }
        public string Title {  get; set; }
        public int Quantity {  get; set; }
        public double Cost {  get; set; }
        public string CustomerFullName { get; set; }
        public string UserFullName { get; set; }
    }
}
