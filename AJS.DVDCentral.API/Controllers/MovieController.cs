using AJS.DVDCentral.BL;
using AJS.DVDCentral.BL.Models;
using AJS.DVDCentral.PL2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AJS.DVDCentral.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : GenericController<Movie, MovieManager>
    {
        
        public MovieController(ILogger<MovieController> logger, DbContextOptions<DVDCentralEntities> options) : base(logger,options)
        {
            logger.LogWarning("Movie Controller Check");
        }

        /// <summary>
        /// Returns a list of movies.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IEnumerable<BL.Models.Movie> Get()
        {
            return new MovieManager(options).Load();
        }

        /// <summary>
        /// Returns a list of movies by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public BL.Models.Movie Get(Guid id)
        {
            return new MovieManager(options).LoadById(id);
        }

        [HttpPost("{rollback?}")]
        public int Post([FromBody] BL.Models.Movie movie, bool rollback = false)
        {
            try
            {
                return new MovieManager(options).Insert(movie, rollback);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] BL.Models.Movie movie, bool rollback = false)
        {
            try
            {
                return new MovieManager(options).Update(movie, rollback);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }



        [HttpDelete("{id}/{rollback?}")]
        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                return new MovieManager(options).Delete(id, rollback);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }

    }
}
