
using AppEmail.Models;
using Microsoft.EntityFrameworkCore;

namespace AppEmail.Services
{
    public class UserService : IUserService
    {
        private readonly DbemailContext _context;

        public UserService(DbemailContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUser(string name, string password)
        {
            User user = await _context.Users.Where(u => u.Name == name && u.Password == password).FirstOrDefaultAsync();
            return user;
        }
    }
}
