using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace VehicleStore.Server.Services.AuthTokenHandler
{
    public class AuthTokenHandler : IAuthTokenHandler
    {
        private const string TokenSecret = "thisIsTokenSecret";
        private static readonly TimeSpan tokenLifeTime = TimeSpan.FromHours(8);

        public AuthTokenHandler()
        { }

        public string Generate(Guid id, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenSecret));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var claims = new List<Claim>
            {
                new Claim("id", id.ToString()),
                new Claim("role", role)
            };

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.Add(tokenLifeTime),
                    signingCredentials: signingCredentials
                );

            var jwt = tokenHandler.WriteToken(token);
            return jwt;
        }
    }
}