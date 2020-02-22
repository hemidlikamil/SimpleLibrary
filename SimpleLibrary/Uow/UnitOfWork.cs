using SimpleLibrary.Models;
using SimpleLibrary.Repository;

namespace SimpleLibrary.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            EmployeeRepo = new EmployeeRepository(_context);
            UserRepo = new UserRepository(_context);
        }
        public IUserRepository UserRepo { get; }

        public IEmployeeRepository EmployeeRepo { get; }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}