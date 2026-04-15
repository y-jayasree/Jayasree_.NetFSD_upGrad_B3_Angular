using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Data;
using WebApplication6.DTOs;
using WebApplication6.Helpers;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtHelper _jwt;

        public AuthController(AppDbContext context, JwtHelper jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new User
            {
                Username = dto.Username,
                Password = dto.Password,
                Role = "User"   
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok("User Registered");
        }

        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAdmin(RegisterDTO dto)
        {
            var user = new User
            {
                Username = dto.Username,
                Password = dto.Password,
                Role = "Admin"
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok("Admin Registered");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x =>
                    x.Username == dto.Username &&
                    x.Password == dto.Password);

            if (user == null)
                return Unauthorized("Invalid credentials");

            var token = _jwt.GenerateToken(user);

            return Ok(new { token });
        }
    }
}
