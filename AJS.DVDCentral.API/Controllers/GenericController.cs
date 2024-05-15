using Microsoft.AspNetCore.Mvc;
using AJS.DVDCentral.API.Controllers;
using AJS.DVDCentral.PL2.Data;
using Microsoft.EntityFrameworkCore;
using AJS.DVDCentral.BL.Models;
using AJS.DVDCentral.BL;

namespace AJS.DVDCentral.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    public class GenericController<T, U> : ControllerBase // T is Entity Type and U is Manager Type.
    {
        protected DbContextOptions<DVDCentralEntities> options;
        protected readonly ILogger logger;
        dynamic manager; // This is where we are going to put the specific Manager for the variable U.

        public GenericController(ILogger logger,
                                 DbContextOptions<DVDCentralEntities> options)
        {
            this.options = options;
            this.logger = logger;
            manager = (U)Activator.CreateInstance(typeof(U), logger, options); // Most important line here.
        }

        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            try
            {
                return Ok(await manager.LoadAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(Guid id)
        {
            try
            {
                return Ok(await manager.LoadByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("{rollback?}")]
        public async Task<ActionResult> Post([FromBody] T entity, bool rollback = false)
        {
            try
            {
                Guid id = await manager.InsertAsync(entity, rollback);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //[HttpPut("{id}/{rollback?}")]
        //public int Put(Guid id, [FromBody] Format format, bool rollback = false)
        //{
        //    try
        //    {
        //        return new FormatManager(options).Update(format, rollback);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[HttpDelete("{id}/{rollback?}")]
        //public int Delete(Guid id, bool rollback = false)
        //{
        //    try
        //    {
        //        return new FormatManager(options).Delete(id, rollback);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
