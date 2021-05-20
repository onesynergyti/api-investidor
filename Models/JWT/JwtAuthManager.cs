using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API_Investidor.Models.JWT
{
    public interface IJwtAuthManager
    {
        TokenInformation GerarToken(ClaimsIdentity claims);
    }

    public class TokenInformation
    {
        public DateTime Expiration { get; set; }

        public string AccessToken { get; set; }
    }

    public class JwtAuthManager : IJwtAuthManager
    {
        private JwtTokenConfig _jwtTokenConfig;

        public JwtAuthManager(JwtTokenConfig jwtTokenConfig)
        {
            _jwtTokenConfig = jwtTokenConfig;
        }

        public TokenInformation GerarToken(ClaimsIdentity claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtTokenConfig.Key);
            DateTime ExpiresToken = DateTime.UtcNow.AddYears(50);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = ExpiresToken,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var tokenInformation = new TokenInformation();
            tokenInformation.Expiration = ExpiresToken;
            tokenInformation.AccessToken = tokenHandler.WriteToken(token);

            return tokenInformation;
        }
    }
}
