using WebApplication9.Data;
using WebApplication9.DTOs;
using WebApplication9.Helpers;
using WebApplication9.Models;
using Microsoft.EntityFrameworkCore;


namespace WebApplication9.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly JwtHelper _jwt;

        public AuthService(AppDbContext context, JwtHelper jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        public async Task<string> Register(RegisterDto dto)
        {
            var user = new UserInfo
            {
                EmailId = dto.EmailId,
                Password = dto.Password,
                Role = dto.Role
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return "User Registered";
        }

        public async Task<string> Login(LoginDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.EmailId == dto.EmailId && x.Password == dto.Password);

            if (user == null)
                return "Invalid Credentials";

            return _jwt.GenerateToken(user);
        }
    }
}
