using AJS.DVDCentral.BL;
using AJS.DVDCentral.BL.Models;
using AJS.DVDCentral.PL2.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AJS.DVDCentral.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : GenericController<Director, DirectorManager>
    {
        public DirectorController(ILogger logger, DbContextOptions<DVDCentralEntities> options) : base(logger, options)
        {
        }





    }
}
