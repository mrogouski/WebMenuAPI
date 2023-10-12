using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebMenuAPI.Data;
using WebMenuAPI.Data.Models;

namespace WebMenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly WebMenuContext _context;

        public AuthenticationController(WebMenuContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpPost()]
        [AllowAnonymous]
        public IActionResult Login([FromBody] Login login)
        {
            if (login is null)
            {
                return BadRequest();
            }

            //var user = _context.Users.Where(x => x.UserName == login.UserName).FirstOrDefault();

            if (login.UserName == "test" && login.Password == "test")
            {
                var issuer = ConfigurationManager.AppSettings["JWT:Issuer"];
                var audience = ConfigurationManager.AppSettings["JWT:Audience"];
                var key = Encoding.ASCII.GetBytes(ConfigurationManager.AppSettings["JWT:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, login.UserName),
                        new Claim(JwtRegisteredClaimNames.Email, login.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                //var stringToken = tokenHandler.WriteToken(token);
                //var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["JWT:Key"]));
                //var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                //var tokeOptions = new JwtSecurityToken(issuer: ConfigurationManager.AppSettings["JWT:ValidIssuer"], audience: ConfigurationManager.AppSettings["JWT:ValidAudience"], claims: new List<Claim>(), expires: DateTime.Now.AddMinutes(6), signingCredentials: signinCredentials);
                //var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new JwtTokenResponse
                {
                    Token = jwtToken
                });
                //return Ok(user);
            }

            return Unauthorized();
        }

        //public IActionResult Logout()
        //{

        //}
    }
}
