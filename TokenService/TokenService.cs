using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using AuthServiceProject.UserRepository;
using AuthServiceProject.Models;

namespace AuthServiceProject.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly IUserRepository<User, UserLoan> _repository;
        readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration configuration, IUserRepository<User, UserLoan> repository)
        {
            _repository = repository;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }
        public async Task<string> CreateToken(User user)
        {
            if(!await _repository.ValidateUser(user))
            {
                return "";
            }
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.UId)
            };
            var credential = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(15),
                SigningCredentials = credential
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
        public async Task<Boolean> ValidateUser(User user)
        {
            var isValid = await _repository.ValidateUser(user);
            return isValid;
        }
    }
}
