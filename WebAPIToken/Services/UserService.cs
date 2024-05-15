using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPIToken.Entities;
using WebAPIToken.Helpers;
using WebAPIToken.Models;

namespace WebAPIToken.Services
{

    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest request);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }

    public class UserService : IUserService
    {
        private readonly AppSettings appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }

        private List<User> _users = new List<User>
        {
            new User() { Id = 1, UserName = "bfoote", FirstName = "Brian", LastName = "Foote", Password = "maple"},
            new User() { Id = 2, UserName = "asteffes", FirstName = "Austin", LastName = "Steffes", Password = "maple"}
        };

        public AuthenticateResponse Authenticate(AuthenticateRequest request)
        {
            // Deciding if the user is good or bad.
            var user = _users.SingleOrDefault(x => x.UserName == request.Username && x.Password == request.Password);
            if (user == null)
            {
                return null;
            }

            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        private string generateJwtToken(User user)
        {
            // Going to generate and create a token that lasts for 7ds in real time.
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }
    }
}
