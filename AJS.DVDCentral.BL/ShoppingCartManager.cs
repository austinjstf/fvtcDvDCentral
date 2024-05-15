using AJS.DVDCentral.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AJS.DVDCentral.BL
{
    public class ShoppingCartManager : GenericManager<tblCart>
    {
        public ShoppingCartManager(DbContextOptions<DVDCentralEntities> options) : base(options)
        {
        }

        public void Add(ShoppingCart cart, Movie movie)
        {
            if (cart != null) { cart.Movies.Add(movie); }
        }

        public void Remove(ShoppingCart cart, Movie movie)
        {
            if (cart != null) { cart.Movies.Remove(movie); }
        }

        public void Checkout(ShoppingCart cart)
        {
            try
            {
                // Make a new order
                Order newOrder = new Order();

                // Set order fields
                newOrder.CustomerId = Guid.NewGuid();
                newOrder.UserId = Guid.NewGuid();
                newOrder.OrderDate = DateTime.Now;
                newOrder.ShipDate = DateTime.Now.AddDays(3);

                // Insert into Order to get the generated Id
                //OrderManager.Insert(newOrder);

                foreach (Movie m in cart.Movies)
                {
                    // Create a new order item
                    OrderItem orderItem = new OrderItem();

                    // Set order item fields

                    orderItem.OrderId = newOrder.Id;
                    orderItem.MovieId = m.Id;
                    orderItem.Quantity = 1; // C.
                    orderItem.Cost = newOrder.Total;

                    // Add the order item to the order
                    newOrder.OrderItems.Add(orderItem);

                    // Decrement tblMovie appropriately.
                    //Movie mo = MovieManager(options).LoadById(m.Id);
                    //mo.InStkQty--;
                }

                // Clear shopping cart.
                cart.Movies.Clear();
            }
            catch (Exception ex)
            {
                throw new Exception("Problem occured here." + ex.Message);
            }
        }
    }
}
