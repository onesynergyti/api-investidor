using API_Investidor.Data.Entities;
using API_Investidor.Models.JWT;
using API_Investidor.Models.Login;
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
        Token GerarToken(LoginAskCode dados);

        TokenInformation GerarJWT(LoginCheckCode dados);
    }

    public class LoginService : RootService, ILoginService
    {
        protected readonly IClientesRepository _clientesRepository;
        protected readonly IZenviaService _zenviaService;
        protected readonly ITokensService _tokensService;
        private JwtTokenConfig _jwtTokenConfig;

        public LoginService(IClientesRepository clientesRepository, 
            IActionContextAccessor actionContextAccessor,
            IZenviaService zenviaService,
            ITokensService tokensService,
            JwtTokenConfig jwtTokenConfig) : base(actionContextAccessor)
        {
            _clientesRepository = clientesRepository;
            _zenviaService = zenviaService;
            _tokensService = tokensService;
            _jwtTokenConfig = jwtTokenConfig;
        }
        
        private string RandomToken(int size)
        {
            Random random = new Random();

            var builder = new StringBuilder(size);

            char offset = 'A';
            const int lettersOffset = 26;

            for (var i = 0; i < size; i++)
            {
                var @char = (char)random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return builder.ToString();
        }

        public Token GerarToken(LoginAskCode dados)
        {
            // Verifica se o cliente existe
            var cliente = _clientesRepository.GetCliente(dados.IdCliente);
            if (cliente == null)
            {
                AddModelError("Cliente não localizado.");
                return default;
            }

            // Verifica se existe um token válido
            var token = _tokensService.GetClienteToken(cliente.IDCLIENTE);

            if (token != null)
            {
                token.AUTH = dados.Telefone;
                _tokensService.Update(token);
                return token;
            }

            // Inclui um novo token
            token = new Token
            {
                IDCLIENTE = cliente.IDCLIENTE,
                CODIGO = RandomToken(6),
                AUTH = dados.Telefone,
                DATACADASTRO = DateTime.Now,
                DATAEXPIRA = DateTime.Now.AddMinutes(15)
            };
            _tokensService.Add(token);

            return token;
        }

        public TokenInformation GerarJWT(LoginCheckCode dados)
        {
            return default;

/*            var cliente = _clientesRepository.GetClientePorTelefone(dados.Telefone);
            
            if (cliente == null)
            {
                AddModelError("Não foi possível validar o usuário.");
                return(default);
            }

            var claims = new ClaimsIdentity(new Claim[]
            {
                    new Claim("IdCliente", cliente.IDCLIENTE.ToString()),
                    new Claim("Telefone", dados.Telefone)
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
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var tokenInformation = new TokenInformation();
            tokenInformation.Expiration = ExpiresToken;
            tokenInformation.AccessToken = tokenHandler.WriteToken(token);

            return tokenInformation;*/
        }
    }
}
