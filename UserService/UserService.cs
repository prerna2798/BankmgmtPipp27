using AuthServiceProject.Models;
using AuthServiceProject.UserRepository;
using System.Threading.Tasks;

namespace AuthServiceProject.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User, UserLoan> _repository;
        public UserService(IUserRepository<User, UserLoan> repository)
        {
            _repository = repository;
        }
        public async Task AddUser(User user)
        {
            await _repository.AddUser(user);
        }

        public async Task<User> GetUser(string id)
        {
           return await _repository.GetUser(id);
        }

        public async Task<UserLoan> GetUserLoan(string id)
        {
            return await _repository.GetUserLoan(id);
        }

        public async Task ApplyLoan(UserLoan userLoan)
        {
            await _repository.ApplyLoan(userLoan);
        }

        public async Task UpdateUser(User user)
        {
            await _repository.UpdateUser(user);
        }
    }
}
