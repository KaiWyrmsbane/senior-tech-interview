using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PatientViewer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PatientViewer.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class LoginController : ControllerBase
        {
            private readonly IConfiguration _configuration;

            public LoginController(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            [HttpPost]
            public IActionResult Login(LoginModel model)
            {
                // Authenticate user credentials (you can replace this with your own authentication logic)
                if (model.Username == "admin" && model.Password == "password")
                {
                    // Generate token
                    var token = GenerateToken(model.Username);

                    // Return token as response
                    return Ok(new { Token = token });
                }

                // Unauthorized access
                return Unauthorized();
            }

            private string GenerateToken(string username)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name, username)
                }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
        }
    }

