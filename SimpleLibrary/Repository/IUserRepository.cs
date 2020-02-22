using SimpleLibrary.Models;

namespace SimpleLibrary.Repository
{
    public interface IUserRepository
    {
        User GetBy(string username, string password);
        User GetBy(string username);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}