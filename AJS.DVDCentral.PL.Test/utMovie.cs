
namespace AJS.DVDCentral.PL.Test
{
    [TestClass]
    public class utMovie : utBase<tblMovie>
    {
        // Loading test for our stored procedure.
        [TestMethod]
        public void LoadTestSP()
        {
            var results = dc.Set<spGetMoviesResult>().FromSqlRaw("exec spGetMovies").ToList();
            Assert.AreEqual(7, results.Count);
        }


        // Loading test for our stored procedure with parameters.
        [TestMethod]
        public void LoadByGenreTest()
        {
            int expected = 2;
            var parameter1 = new SqlParameter
            {
                ParameterName = "GenreName", SqlDbType = System.Data.SqlDbType.VarChar, Value = "sc"
            };

            var results = dc.Set<spGetMoviesResult>().FromSqlRaw("exec spGetMoviesByGenre @GenreName", parameter1).ToList();

            // Also could do, List<spGetMoviesResult> instead of var results. 
            // Then, string title = results[1].Title.

            string title = "";
            foreach (var item in results)
            {
                title = item.Title;
            }

            Assert.AreEqual("Jaws", title);
            Assert.AreEqual(expected, results.Count);
        }


        [TestMethod]
        public void LoadTest()
        {
            int expected = 7;
            var movies = base.LoadTest();
            Assert.AreEqual(expected, movies.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblMovie entity = new tblMovie();
            entity.Id = Guid.NewGuid();
            entity.Title = "Test";
            entity.Description = "Test";
            entity.FormatId = base.LoadTest().FirstOrDefault().FormatId;
            entity.DirectorId = base.LoadTest().FirstOrDefault().DirectorId;
            entity.RatingId = base.LoadTest().FirstOrDefault().RatingId;
            entity.Cost = 1;
            entity.Quantity = 1;
            entity.ImagePath = "Test";

            Assert.AreEqual(1, base.InsertTest(entity));
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblMovie entity = base.LoadTest().FirstOrDefault();

            entity.Description = "TestMovie";

            Assert.IsTrue(base.UpdateTest(entity) > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblMovie entity = base.LoadTest().FirstOrDefault(x => x.Description == "Other");

            Assert.AreNotEqual(base.DeleteTest(entity), 0);
        }
    }
}
