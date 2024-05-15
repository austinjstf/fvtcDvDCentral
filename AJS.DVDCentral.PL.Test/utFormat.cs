namespace AJS.DVDCentral.PL.Test
{
    [TestClass]
    public class utFormat : utBase<tblFormat>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 4;
            var formats = base.LoadTest();
            Assert.AreEqual(2, formats[1].tblMovies.Count);
            Assert.AreEqual(expected, formats.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblFormat entity = new tblFormat();
            entity.Id = Guid.NewGuid();
            entity.Description = "Test";

            Assert.AreEqual(1, base.InsertTest(entity));
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblFormat entity = base.LoadTest().FirstOrDefault();

            entity.Description = "Test";

            Assert.IsTrue(base.UpdateTest(entity) > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblFormat entity = base.LoadTest().FirstOrDefault(x => x.Description == "Other");

            Assert.AreNotEqual(base.DeleteTest(entity), 0);
        }
    }
}
