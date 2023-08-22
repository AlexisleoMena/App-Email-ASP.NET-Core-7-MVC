using AppEmail.Models;

namespace AppEmail.Services
{
    public interface IUserService
    {
        Task<User> GetUser(string name, string password);
        Task<User> AddUser(User user);
    }
}
