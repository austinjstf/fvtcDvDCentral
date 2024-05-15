using AJS.DVDCentral.BL.Models;

namespace AJS.DVDCentral.UI.ViewModels
{
    public class OrderVM
    {
        public Order order { get; set; }

        public OrderItem orderItems { get; set; }

        public Movie movie { get; set; }

        public User user { get; set; }

        public Customer customer { get; set; }  
    }
}
