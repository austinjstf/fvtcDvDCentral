namespace AJS.DVDCentral.PL.Test
{
    [TestClass]
    public class utDirector : utBase<tblDirector>
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(6, base.LoadTest().Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblDirector entity = new tblDirector();

            entity.Id = Guid.NewGuid();
            entity.FirstName = "Test";
            entity.LastName = "Test";

            Assert.AreEqual(1, base.InsertTest(entity));
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblDirector entity = base.LoadTest().FirstOrDefault();

            entity.FirstName = "Test";
            entity.LastName = "Test";

            Assert.IsTrue(base.UpdateTest(entity) > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblDirector entity = base.LoadTest().FirstOrDefault(x => x.LastName == "Other");

            Assert.AreNotEqual(base.DeleteTest(entity), 0);
        }
    }
}
