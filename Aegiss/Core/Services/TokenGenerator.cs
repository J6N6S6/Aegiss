using System.Text.Json;
using JWT;
using JWT.Builder;
using JWT.Algorithms;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;


namespace Aegiss.Core.Services
{
    public class TokenGenerator
    {
        private readonly string _secretKey = "0c51d78b6648a3e55990b8356415a1a154a30abd6205cdc1e8936e18fa4990a2";

        public string GenerateToken(long userId, int roleId = 666, int expireMinutes = 60)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]  //Subject é o payload do token,
                { new Claim("roleId", roleId.ToString()), new Claim("UserId", userId.ToString())}),  //Claim só passa String no token
                Expires = DateTime.UtcNow.AddMinutes(expireMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
