namespace AJS.DVDCentral.PL.Test
{
    [TestClass]
    public class utOrderItem : utBase<tblOrderItem>
    {
       
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, base.LoadTest().Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblOrderItem entity = new tblOrderItem();
            entity.Id = Guid.NewGuid();
            entity.OrderId = dc.tblOrderItems.FirstOrDefault().OrderId;
            entity.Quantity = 10;
            entity.MovieId = dc.tblOrderItems.FirstOrDefault().MovieId;
            entity.Cost = 10;

            Assert.AreEqual(1, base.InsertTest(entity));
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblOrderItem entity = base.LoadTest().FirstOrDefault();

            entity.OrderId = dc.tblOrderItems.FirstOrDefault().OrderId;
            entity.MovieId = dc.tblOrderItems.FirstOrDefault().MovieId;

            Assert.IsTrue(base.UpdateTest(entity) > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblOrderItem entity = base.LoadTest().FirstOrDefault();

            Assert.AreNotEqual(base.DeleteTest(entity), 0);
        }
    }
}
