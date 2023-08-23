
using AppEmail.Models;
//using AppEmail.Resources;
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
            //user.Password = Utils.EncryptPassword(user.Password);
            user.SetPassword(user.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUser(string email, string password)
        {
            //password = Utils.EncryptPassword(password);
            var usersInMemory = await _context.Users.ToListAsync();
            //User user = usersInMemory.FirstOrDefault(u => u.Email == email && u.Password == password);
            User user = usersInMemory.FirstOrDefault(u => u.Email == email && u.VerifyPassword(password));
            return user;
        }
    }
}
