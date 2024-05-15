using AJS.DVDCentral.BL;
using AJS.DVDCentral.BL.Models;
using Castle.Core.Resource;
using Microsoft.Extensions.Options;

namespace AJS.DVDCentral.PL.Test
{
    [TestClass]
    public class utCustomer : utBase<tblCustomer>
    {

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, base.LoadTest().Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblCustomer entity = new tblCustomer();
            entity.Id = Guid.NewGuid();
            entity.FirstName = "Test";
            entity.LastName = "Test";
            entity.UserId = dc.tblCustomers.FirstOrDefault().UserId;
            entity.Address = "Test";
            entity.City = "Test";
            entity.State = "TE";
            entity.ZIP = "Test";
            entity.Phone = "Test";

         
            Assert.AreEqual(1, base.InsertTest(entity));
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblCustomer entity = base.LoadTest().FirstOrDefault();

            entity.FirstName = "Test";
            entity.LastName = "Test";

            Assert.IsTrue(base.UpdateTest(entity) > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblCustomer row = base.LoadTest().FirstOrDefault(x => x.Orders.Count == 0);
            if (row != null)
            {
                int rowsAffected = DeleteTest(row);
                Assert.IsTrue(rowsAffected == 1);
            }
        }

        //[TestMethod]
        //public void LoadByIdTest()
        //{
        //    Customer customer = new CustomerManager(options).Load().FirstOrDefault();
        //    Assert.AreEqual(new CustomerManager(options).LoadById(customer.Id).Id, customer.Id);
        //}
    }
}
