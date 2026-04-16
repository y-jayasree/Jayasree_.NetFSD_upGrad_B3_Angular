using AuthService.Data;
using AuthService.DTOs;
using AuthService.Helpers;
using AuthService.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace AuthService.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthDbContext _context;
        private readonly JwtHelper _jwt;

        public AuthService(AuthDbContext context, JwtHelper jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        public async Task<string> RegisterUser(RegisterDto dto)
        {
            Log.Information("User registration request: {Email}", dto.Email);

            var existing = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
            if (existing != null)
            {
                Log.Warning("User already exists: {Email}", dto.Email);
                return "User already exists";
            }

            var user = new User
            {
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = "User"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            Log.Information("User registered successfully: {Email}", dto.Email);

            return "User Registered Successfully";
        }

        public async Task<string> RegisterAdmin(RegisterDto dto)
        {
            Log.Information("Admin registration request: {Email}", dto.Email);

            var existing = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
            if (existing != null)
            {
                Log.Warning("Admin already exists: {Email}", dto.Email);
                return "User already exists";
            }

            var admin = new User
            {
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = "Admin"
            };

            _context.Users.Add(admin);
            await _context.SaveChangesAsync();

            Log.Information("Admin registered successfully: {Email}", dto.Email);

            return "Admin Registered Successfully";
        }

        public async Task<string> Login(LoginDto dto)
        {
            Log.Information("Login attempt: {Email}", dto.Email);

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);

            if (user == null)
            {
                Log.Warning("Login failed (user not found): {Email}", dto.Email);
                return "Invalid User";
            }

            bool isValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);

            if (!isValid)
            {
                Log.Warning("Login failed (wrong password): {Email}", dto.Email);
                return "Invalid Password";
            }

            var token = _jwt.GenerateToken(user);

            Log.Information("Login successful: {Email}", dto.Email);

            return token;
        }
    }
}
