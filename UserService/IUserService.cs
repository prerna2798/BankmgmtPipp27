using AuthServiceProject.Models;
using System.Threading.Tasks;

namespace AuthServiceProject.UserService
{
    public interface IUserService
    {
        public Task AddUser(User user);
        public Task<User> GetUser(string id);
        public Task UpdateUser(User user);
        public Task<UserLoan> GetUserLoan(string id);
        public Task ApplyLoan(UserLoan userLoan);
    }
}
