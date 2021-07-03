using AuthServiceProject.Models;
using System;
using System.Threading.Tasks;

namespace AuthServiceProject.UserRepository
{
    public class UserRepository : IUserRepository<User,UserLoan>
    {
        readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<Boolean> ValidateUser(User user)
        {
            var userItem = await _context.Users.FindAsync(user.UId);
            if (userItem == null)
                return false;
            else if (userItem.Password == user.Password)
                return true;
            else
                return false;

        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUser(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<UserLoan> GetUserLoan(string id)
        {
            return await _context.UserLoans.FindAsync(id);
        }

        public async Task ApplyLoan(UserLoan userLoan)
        {
            await _context.UserLoans.AddAsync(userLoan);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
           _context.Users.Update(user);
           await _context.SaveChangesAsync();
        }

    }
}
