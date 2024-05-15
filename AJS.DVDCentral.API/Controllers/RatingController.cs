using AJS.DVDCentral.BL;
using AJS.DVDCentral.BL.Models;
using AJS.DVDCentral.PL2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AJS.DVDCentral.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : GenericController<Rating, RatingManager>
    {   
        public RatingController(ILogger<RatingController> logger, DbContextOptions<DVDCentralEntities> options) : base(logger,options)
        {
            logger.LogWarning("Rating Controller Check");
        }

        [HttpGet]
        public IEnumerable<BL.Models.Rating> Get()
        {
            return new RatingManager(options).Load();
        }

        [HttpGet("{id}")]
        public BL.Models.Rating Get(Guid id)
        {
            return new RatingManager(options).LoadById(id);
        }

        [HttpPost("{rollback?}")]
        public int Post([FromBody] BL.Models.Rating rating, bool rollback = false)
        {
            try
            {
                return new RatingManager(options).Insert(rating, rollback);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] BL.Models.Rating rating, bool rollback = false)
        {
            try
            {
                return new RatingManager(options).Update(rating, rollback);
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
                return new RatingManager(options).Delete(id, rollback);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }

    }
}
