using Microsoft.AspNetCore.Mvc;
using TokenizationExample.Models;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TokenizationExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
           _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            LoginResult result = new LoginResult();



            if (user.username == "admin" && user.password == "admin")
            {
                result.status = "success";
                result.user = user;

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration.GetValue<string>("Jwt:Subject")),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", "0"),
                    new Claim("UserName", user.username),
                    new Claim("Password", user.password)

                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Jwt:Key")));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration.GetValue<string>("Jwt:Issuer"),
                     _configuration.GetValue<string>("Jwt:Audience"),
                    claims,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: signIn
                );

                result.token = new JwtSecurityTokenHandler().WriteToken(token);
            }
            else
            {
                result.status = "failed";
            }
            return Ok(result);
        }
    }
}
