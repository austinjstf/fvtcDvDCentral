using AJS.DVDCentral.BL;
using AJS.DVDCentral.BL.Models;
using AJS.DVDCentral.PL2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AJS.DVDCentral.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatController : GenericController<Format, FormatManager>
    {

        public FormatController(ILogger logger, DbContextOptions<DVDCentralEntities> options) : base(logger, options)
        {
            logger.LogWarning("Format Controller Check");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BL.Models.Format>>> Get()
        {
            try
            {
                return Ok(await new FormatManager(options).LoadAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        [HttpGet("{id}")]
        public BL.Models.Format Get(Guid id)
        {
            return new FormatManager(options).LoadById(id);
        }

        [HttpPost("{rollback?}")]
        public int Post([FromBody] BL.Models.Format format, bool rollback = false)
        {
            try
            {
                return new FormatManager(options).Insert(format, rollback);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] BL.Models.Format format, bool rollback = false)
        {
            try
            {
                return new FormatManager(options).Update(format, rollback);
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
                return new FormatManager(options).Delete(id, rollback);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }

    }
}
