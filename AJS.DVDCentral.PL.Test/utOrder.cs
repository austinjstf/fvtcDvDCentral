using AJS.DVDCentral.BL.Models;
using AJS.DVDCentral.BL;
using Microsoft.Extensions.Options;

namespace AJS.DVDCentral.PL.Test
{
    [TestClass]
    public class utOrder : utBase<tblOrder>
    {
       
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, base.LoadTest().Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblOrder entity = new tblOrder();
            entity.Id = Guid.NewGuid();
            entity.CustomerId = dc.tblOrders.FirstOrDefault().CustomerId;
            entity.OrderDate = DateTime.Now;
            entity.UserId = dc.tblOrders.FirstOrDefault().UserId;
            entity.ShipDate = DateTime.Now;

            Assert.AreEqual(1, base.InsertTest(entity));
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblOrder entity = base.LoadTest().FirstOrDefault();

            entity.CustomerId = dc.tblOrders.FirstOrDefault().CustomerId;
            entity.UserId = dc.tblOrders.FirstOrDefault().UserId;

            Assert.IsTrue(base.UpdateTest(entity) > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblOrder entity = base.LoadTest().FirstOrDefault();

            Assert.AreNotEqual(base.DeleteTest(entity), 0);
        }

        //[TestMethod]
        //public void LoadByIdTest()
        //{
        //    Guid id = new OrderManager(options).Load().LastOrDefault().Id;
        //    Order order = new OrderManager(options).LoadById(id);
        //    Assert.AreEqual(order.Id, id);
        //    Assert.IsTrue(order.OrderItems.Count > 0);
        //}
    }
}
