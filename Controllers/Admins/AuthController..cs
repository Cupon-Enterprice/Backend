using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Backend.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers.Admins
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;
        private readonly string _key;
        public AuthController(IAuthService authService, DataContext context)
        {
            _authService = authService;
            _context = context;
            _key = "a!D3f7kL8Mn2Pq4R6tVzX9wB1GhJkZ2Y";
        }
        [HttpPost("Auth")]
        public async Task<IActionResult> Auth([FromBody] Autorize loginRequest)
        {
            var admin = await _authService.Authenticate(loginRequest.Correo, loginRequest.Clave);
            var admin2 = await _context.Admins.FirstOrDefaultAsync(t => t.Correo == loginRequest.Correo && t.Clave == loginRequest.Clave);

            if (admin2 == null)
            {
                return Unauthorized("usuario invalido");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, admin2.Nombre),
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "https://localhost:5025",
                Audience = "https://localhost:5025"
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new { Token = tokenString });
        }
    }
}
