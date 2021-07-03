using System;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServiceProject.UserRepository
{
    public interface IUserRepository<User,UserLoan>
    {
        public Task<Boolean> ValidateUser(User user);
        public Task AddUser(User user);
        public Task<UserLoan> GetUserLoan(string id);
        public Task ApplyLoan(UserLoan userLoan);
        public Task<User> GetUser(string id);
        public Task UpdateUser(User user);

    }
}
