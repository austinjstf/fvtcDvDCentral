﻿
namespace AJS.DVDCentral.BL
{
    public class MovieManager : GenericManager<tblMovie>
    {
        public MovieManager(DbContextOptions<DVDCentralEntities> options) : base(options) { }

        private static List<Genre> ConvertToGenres(ICollection<tblMovieGenre> moviegenres)
        {
            List<Genre> genres = new List<Genre>();
            foreach (tblMovieGenre mg in moviegenres)
            {
                genres.Add(new Genre { Id = mg.GenreId, Description = mg.Genre.Description });
            }
            return genres;
        }

        private static List<tblMovieGenre> ConvertToMovieGenres(Movie movie)
        {
            List<tblMovieGenre> moviegenres = new List<tblMovieGenre>();
            foreach (Genre g in movie.Genres)
            {
                moviegenres.Add(new tblMovieGenre { Id = Guid.NewGuid(), MovieId = movie.Id, GenreId = g.Id });
            }
            return moviegenres;
        }

        public List<Movie> Load()
        {
            try
            {
                List<Movie> movies = new List<Movie>();

                using (DVDCentralEntities dc = new DVDCentralEntities(options))
                {
                    movies = (from m in dc.tblMovies
                              join mr in dc.tblRatings on m.RatingId equals mr.Id
                              join md in dc.tblDirectors on m.DirectorId equals md.Id
                              join mf in dc.tblFormats on m.FormatId equals mf.Id
                              select new Movie
                              {
                                  Id = m.Id,
                                  Title = m.Title,
                                  Description = m.Description,
                                  Cost = m.Cost,
                                  RatingId = m.RatingId,
                                  FormatId = m.FormatId,
                                  DirectorId = m.DirectorId,
                                  Quantity = m.Quantity,
                                  ImagePath = m.ImagePath,
                                  RatingDescription = mr.Description,
                                  FormatDescription = mf.Description,
                                  DirectorFullName = md.LastName + ", " + md.FirstName,
                                  Genres = new GenreManager(options).Load(m.Id)
                              }
                              )
                              .OrderBy(m => m.Title)
                              .ToList();
                }
                return movies;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Movie LoadById(Guid id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities(options))
                {
                    tblMovie row = dc.tblMovies.FirstOrDefault(m => m.Id == id);
                    if (row != null)
                    {
                        Movie movie = new Movie
                        {
                            Id = row.Id,
                            Title = row.Title,
                            Description = row.Description,
                            Cost = row.Cost,
                            RatingId = row.RatingId,
                            FormatId = row.FormatId,
                            DirectorId = row.DirectorId,
                            Quantity = row.Quantity,
                            ImagePath = row.ImagePath,
                            //DirectorFullName = DirectorManager.LoadById(row.DirectorId).FullName,
                            //FormatDescription = FormatManager.LoadById(row.FormatId).Description,
                            ///RatingDescription = RatingManager.LoadById(row.RatingId).Description,
                            Genres = new GenreManager(options).Load(row.Id)
                        };
                        return movie;
                    }
                    else
                    {
                        throw new Exception("Row not found");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Movie> LoadByGenre(Guid? genreId = null)
        {
            try
            {
                List<Movie> movies = new List<Movie>();

                using (DVDCentralEntities dc = new DVDCentralEntities(options))
                {
                    movies = (from m in dc.tblMovies
                              join mg in dc.tblMovieGenres on m.Id equals mg.MovieId
                              join mr in dc.tblRatings on m.RatingId equals mr.Id
                              join md in dc.tblDirectors on m.DirectorId equals md.Id
                              join mf in dc.tblFormats on m.FormatId equals mf.Id
                              where mg.GenreId == genreId || genreId == null
                              select new Movie
                              {
                                  Id = m.Id,
                                  Title = m.Title,
                                  Description = m.Description,
                                  Cost = m.Cost,
                                  RatingId = m.RatingId,
                                  FormatId = m.FormatId,
                                  DirectorId = m.DirectorId,
                                  Quantity = m.Quantity,
                                  ImagePath = m.ImagePath,
                                  RatingDescription = mr.Description,
                                  FormatDescription = mf.Description,
                                  DirectorFullName = md.LastName + ", " + md.FirstName,
                              }
                              )
                              .Distinct()
                              .OrderBy(m => m.Title)
                              .ToList();
                }

                foreach (Movie movie in movies)
                {
                    movie.Genres = new GenreManager(options).Load(movie.Id);
                }

                return movies;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Insert(Movie movie, bool rollback = false)
        {
            try
            {
                int results = 0;

                using (DVDCentralEntities dc = new DVDCentralEntities(options))
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblMovie newRow = new tblMovie();
                    // Teranary operator
                    newRow.Id = Guid.NewGuid();
                    newRow.Title = movie.Title;
                    newRow.Description = movie.Description;
                    newRow.Cost = movie.Cost;
                    newRow.RatingId = movie.RatingId;
                    newRow.FormatId = movie.FormatId;
                    newRow.DirectorId = movie.DirectorId;
                    newRow.Quantity = movie.Quantity;
                    newRow.ImagePath = movie.ImagePath;

                    // Backfill the id on the input parameter movie
                    movie.Id = newRow.Id;

                    // Insert the genres into tblMovieGenre
                    foreach (Genre genre in movie.Genres)
                    {
                        new MovieGenreManager(options).Insert(movie.Id, genre.Id);
                    }

                    // Insert the row
                    dc.tblMovies.Add(newRow);

                    // Commit the changes and get the number of rows affected
                    results = dc.SaveChanges();

                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int Update(Movie movie, bool rollback = false)
        {
            try
            {
                int results = 0;

                using (DVDCentralEntities dc = new DVDCentralEntities(options))
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblMovie upDateRow = dc.tblMovies.FirstOrDefault(f => f.Id == movie.Id);

                    if (upDateRow != null)
                    {
                        upDateRow.Title = movie.Title;
                        upDateRow.Description = movie.Description;
                        upDateRow.Cost = movie.Cost;
                        upDateRow.RatingId = movie.RatingId;
                        upDateRow.FormatId = movie.FormatId;
                        upDateRow.DirectorId = movie.DirectorId;
                        upDateRow.Quantity = movie.Quantity;
                        upDateRow.ImagePath = movie.ImagePath;

                        // Update the movie genres
                        List<Genre> oldGenres = new GenreManager(options).Load(movie.Id);

                        List<Genre> newGenres = new List<Genre>();
                        if (movie.Genres != null)
                        {
                            newGenres = movie.Genres;
                        }

                        IEnumerable<Genre> deletes = oldGenres.Except(newGenres);
                        IEnumerable<Genre> adds = newGenres.Except(oldGenres);

                        deletes.ToList().ForEach(d => new MovieGenreManager(options).Delete(movie.Id, d.Id));
                        adds.ToList().ForEach(a => new MovieGenreManager(options).Insert(movie.Id, a.Id));

                        dc.tblMovies.Update(upDateRow);

                        // Commit the changes and get the number of rows affected
                        results = dc.SaveChanges();

                        if (rollback) transaction.Rollback();
                    }
                    else
                    {
                        throw new Exception("Row was not found.");
                    }
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                int results = 0;

                using (DVDCentralEntities dc = new DVDCentralEntities(options))
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblMovie deleteRow = dc.tblMovies.FirstOrDefault(f => f.Id == id);

                    if (deleteRow != null)
                    {
                        // delete all the associated tblMovieGenre rows. 
                        var genres = dc.tblMovieGenres.Where(g => g.MovieId == id);
                        dc.tblMovieGenres.RemoveRange(genres);

                        // delete all the associated tblOrderItem rows. 
                        var orderItems = dc.tblOrderItems.Where(i => i.MovieId == id);
                        dc.tblOrderItems.RemoveRange(orderItems);

                        // remove the movie
                        dc.tblMovies.Remove(deleteRow);

                        // Commit the changes and get the number of rows affected
                        results = dc.SaveChanges();

                        if (rollback) transaction.Rollback();
                    }
                    else
                    {
                        throw new Exception("Row was not found.");
                    }
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
