using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIToken.Models;
using WebAPIToken.Services;

namespace WebAPIToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        
        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            try
            {
                var response = _userService.Authenticate(model);
                if (response == null)
                {
                    return BadRequest(new { message = "Bad boy" });
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

    }
}
