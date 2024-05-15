namespace AJS.DVDCentral.PL.Test
{
    [TestClass]
    public class utGenre : utBase<tblGenre>
    {

        [TestMethod]
        public void LoadTest()
        {
            int expected = 10;
            var genres = base.LoadTest();
            Assert.AreEqual(expected, genres.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblGenre entity = new tblGenre();
            entity.Id = Guid.NewGuid();
            entity.Description = "Test";

            dc.tblGenres.Add(entity);
            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblGenre entity = dc.tblGenres.FirstOrDefault();

            entity.Description = "Test";

            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblGenre entity = dc.tblGenres.FirstOrDefault(x => x.Description == "Other");

            dc.tblGenres.Remove(entity);
            int result = dc.SaveChanges();
            Assert.AreNotEqual(result, 0);
        }
    }
}
