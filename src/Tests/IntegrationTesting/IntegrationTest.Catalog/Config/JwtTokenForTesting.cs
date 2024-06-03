using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace IntegrationTest.Catalog.Config
{
    public class JwtTokenForTesting
    {
        public Guid UserId { get; } = JwtTokenProvider.SutUserId;
        public List<Claim> Claims { get; } = JwtTokenProvider.Claims;
        public int ExpireInMinutes { get; set; } = 30;

        public JwtTokenForTesting WithRole(string roleName)
        {
            Claims.Add(new Claim(ClaimTypes.Role, roleName));
            return this;
        }

        public string Build()
        {
            var token = new JwtSecurityToken(
                JwtTokenProvider.Issuer,
                JwtTokenProvider.Issuer,
                this.Claims,
                expires: DateTime.Now.AddMinutes(this.ExpireInMinutes),
                signingCredentials: JwtTokenProvider.SigningCredentials
            );

            return JwtTokenProvider.JwtSecurityTokenHandler.WriteToken(token);
        }
    }
}
