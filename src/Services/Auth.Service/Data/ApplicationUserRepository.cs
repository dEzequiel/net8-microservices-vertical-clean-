using Auth.Service.DTOs;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth.Service.Data
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        public ApplicationUserRepository(ApplicationDbContext context, IConfiguration configuration) {
            _context = context;
            _config = configuration;
        }

        public async Task<LoginApplicationUserResponse> LoginApplicationUserAsync(LoginApplicationUserDTO loginUser)
        {
            var getUser = await FindUserByEmail(loginUser.Email);
            if (getUser is null)
                return new LoginApplicationUserResponse(false, $"User with email {loginUser.Email} not found");

            string token = GenerateToken(getUser);
            return new LoginApplicationUserResponse(true, token);
        }

        public async Task<RegisterApplicationUserResponse> RegisterApplicationUserAsync(RegisterApplicationUserDTO registerUser)
        {
            var getUser = await FindUserByEmail(registerUser.Email);
            if (getUser is not null)
                return new RegisterApplicationUserResponse(false, $"User with email {registerUser.Email} already registered");

            _context.ApplicationUsers.Add(new ApplicationUser()
            {
                Id = Guid.NewGuid(),
                Email = registerUser.Email,
            });

            await _context.SaveChangesAsync();
            return new RegisterApplicationUserResponse(true, $"User registered with email {registerUser.Email}");
        }

        private async Task<ApplicationUser?> FindUserByEmail(string email) =>
            await _context.ApplicationUsers.FirstOrDefaultAsync(u => u.Email == email);

        private string GenerateToken(ApplicationUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Isser"],
                audience: _config["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(5),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
