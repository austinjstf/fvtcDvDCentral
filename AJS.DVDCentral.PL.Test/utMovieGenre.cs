namespace AJS.DVDCentral.PL.Test
{
    [TestClass]
    public class utMovieGenre : utBase<tblMovieGenre>
    {

        [TestMethod]
        public void LoadTest()
        {
            int expected = 13;
            var movieGenres = base.LoadTest();
            Assert.AreEqual(expected, movieGenres.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblMovieGenre entity = new tblMovieGenre();
            entity.Id = Guid.NewGuid();
            entity.MovieId = dc.tblMovieGenres.FirstOrDefault().MovieId;
            entity.GenreId = dc.tblMovieGenres.FirstOrDefault().GenreId;

            Assert.AreEqual(1, base.InsertTest(entity));
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblMovieGenre entity = base.LoadTest().FirstOrDefault();

            entity.MovieId = dc.tblMovieGenres.FirstOrDefault().MovieId;
            entity.GenreId = dc.tblMovieGenres.FirstOrDefault().GenreId;

            Assert.IsTrue(base.UpdateTest(entity) > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblMovieGenre entity = base.LoadTest().FirstOrDefault();

            Assert.AreNotEqual(base.DeleteTest(entity), 0);
        }
    }
}
