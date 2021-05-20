using API_Investidor.Data.Entities;
using API_Investidor.Models.JWT;
using API_Investidor.Models.Login;
using API_Investidor.Models.Zenvia;
using API_Investidor.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API_Investidor.Services
{
    public interface ILoginService
    {
        TokenInformation GerarJWT(LoginCheckCode dados);
    }

    public class LoginService : RootService, ILoginService
    {
        private JwtTokenConfig _jwtTokenConfig;
        private TokensRepository _tokensRepository;

        public LoginService( 
            IActionContextAccessor actionContextAccessor,
            TokensRepository tokensRepository,
            JwtTokenConfig jwtTokenConfig) : base(actionContextAccessor)
        {
            _jwtTokenConfig = jwtTokenConfig;
            _tokensRepository = tokensRepository;
        }

        public TokenInformation GerarJWT(LoginCheckCode dados)
        {
            var token = _tokensRepository.ValidarClienteToken(dados);
            
            if (token == null)
            {
                AddModelError("Não foi possível validar o código informado.");
                return(default);
            }

            var claims = new ClaimsIdentity(new Claim[]
            {
                    new Claim("IdCliente", token.IDCLIENTE.ToString())
            });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtTokenConfig.Key);
            DateTime ExpiresToken = DateTime.UtcNow.AddYears(50);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = ExpiresToken,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenJWT = tokenHandler.CreateToken(tokenDescriptor);

            var tokenInformation = new TokenInformation();
            tokenInformation.Expiration = ExpiresToken;
            tokenInformation.AccessToken = tokenHandler.WriteToken(tokenJWT);

            return tokenInformation;
        }
    }
}
