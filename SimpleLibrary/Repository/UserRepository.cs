using SimpleLibrary.Models;
using System.Data.Entity;
using System.Linq;

namespace SimpleLibrary.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public void Update(User user)
        {
            _context.Users.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
        }

        public void Delete(User user)
        {
            //_context.Users.Attach(User);
            _context.Users.Remove(user);
        }

        public User GetBy(string username, string password)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
        }
        public User GetBy(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }
    }
}