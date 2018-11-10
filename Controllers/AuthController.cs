using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace easy_hotel_backend.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Auth([FromBody] Usuario request)
        {
            if (request.Nome == "teste" && request.Senha == "123456")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, request.Nome)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "easy-hotel",
                    audience: "easy-hotel",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                return Ok(new { toke = new JwtSecurityTokenHandler().WriteToken(token) });

            }
            else
            {
                return BadRequest("Credenciais Invalidas");
            }
        }
    }
}