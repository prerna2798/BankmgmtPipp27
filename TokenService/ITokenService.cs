using AuthServiceProject.Models;
using System;
using System.Threading.Tasks;

namespace AuthServiceProject.TokenService
{
    public interface ITokenService
    {
        public Task<string> CreateToken(User user);

        public Task<Boolean> ValidateUser(User user);

    }
}
