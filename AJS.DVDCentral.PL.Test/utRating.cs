namespace AJS.DVDCentral.PL.Test
{
    [TestClass]
    public class utRating : utBase<tblRating>
    {

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(5, base.LoadTest().Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            tblRating entity = new tblRating();
            entity.Id = Guid.NewGuid();
            entity.Description = "Test";


            Assert.AreEqual(1, base.InsertTest(entity));
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblRating entity = base.LoadTest().FirstOrDefault();

            entity.Description = "Test";

            Assert.IsTrue(base.UpdateTest(entity) > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblRating entity = base.LoadTest().FirstOrDefault(x => x.Description == "Other");

            Assert.AreNotEqual(base.DeleteTest(entity), 0);
        }
    }
}
