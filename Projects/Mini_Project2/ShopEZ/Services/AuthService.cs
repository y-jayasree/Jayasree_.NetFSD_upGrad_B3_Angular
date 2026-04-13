using ShopEZ.Data;
using ShopEZ.DTOs.Auth;
using ShopEZ.Helpers;
using ShopEZ.Models;
using ShopEZ.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ShopEZ.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtHelper _jwt;

        public AuthService(ApplicationDbContext context, JwtHelper jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        // USER REGISTER
        public async Task<AuthResponseDTO> RegisterAsync(RegisterDTO dto)
        {
            var exists = await _context.Users.AnyAsync(u => u.Email == dto.Email);
            if (exists)
                throw new InvalidOperationException("Email already registered.");

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = "Customer"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var token = _jwt.GenerateToken(user);

            return new AuthResponseDTO
            {
                Token = token,
                Role = user.Role,
                Email = user.Email,
                Message = "User registered successfully"
            };
        }

        //ADMIN REGISTER
        public async Task<AuthResponseDTO> RegisterAdminAsync(RegisterDTO dto)
        {
            var exists = await _context.Users.AnyAsync(u => u.Email == dto.Email);
            if (exists)
                throw new InvalidOperationException("Email already registered.");

            var admin = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = "Admin"
            };

            _context.Users.Add(admin);
            await _context.SaveChangesAsync();

            var token = _jwt.GenerateToken(admin);

            return new AuthResponseDTO
            {
                Token = token,
                Role = admin.Role,
                Email = admin.Email,
                Message = "Admin registered successfully"
            };
        }

        //LOGIN
        public async Task<AuthResponseDTO> LoginAsync(LoginDTO dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email)
                ?? throw new UnauthorizedAccessException("Invalid email or password.");

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                throw new UnauthorizedAccessException("Invalid email or password.");

            var token = _jwt.GenerateToken(user);

            return new AuthResponseDTO
            {
                Token = token,
                Role = user.Role,
                Email = user.Email,
                Message = user.Role == "Admin"
                    ? "Admin login successful"
                    : "User login successful"
            };
        }
    }
}
