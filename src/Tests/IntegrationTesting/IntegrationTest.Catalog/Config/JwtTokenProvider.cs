using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IntegrationTest.Catalog.Config
{
    public static class JwtTokenProvider
    {
        public static string Issuer { get; } = "Sample_Auth_Server";
        public static Guid SutUserId { get; } = Guid.NewGuid();
        public static SecurityKey SecurityKey { get; } =
            new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes("This_is_a_super_secure_key_and_you_know_it")
            );
        public static SigningCredentials SigningCredentials { get; } =
            new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

        public static List<Claim> Claims { get; } =
            new List<Claim>
            {
                //new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Sid, SutUserId.ToString()),
            };

        internal static readonly JwtSecurityTokenHandler JwtSecurityTokenHandler = new();
    }
}
