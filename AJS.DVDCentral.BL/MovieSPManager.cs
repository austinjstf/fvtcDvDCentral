using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJS.DVDCentral.BL
{
    public class MovieSPManager : GenericManager<spGetMoviesResult>
    {
        public MovieSPManager(DbContextOptions<DVDCentralEntities> options) : base(options) { }

        public List<spGetMoviesResult> Load(string sql = "spGetMovies")
        {
            try
            {
                List<spGetMoviesResult> movies = new List<spGetMoviesResult>();

                base.Load(sql).ForEach(m => movies.Add(
                    new spGetMoviesResult
                    {
                        Id = m.Id,
                        Title = m.Title,
                        Description = m.Description,
                        Cost = m.Cost,
                        RatingId = m.RatingId,
                        FormatId = m.FormatId,
                        DirectorId = m.DirectorId,
                        Quantity = m.Quantity,
                        RatingDescription = m.Description,
                        FormatDescription = m.Description,
                        FirstName = m.FirstName,
                        LastName = m.LastName,
                    }));

                return movies;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
