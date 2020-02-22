using SimpleLibrary.Repository;

namespace SimpleLibrary.Uow
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepo { get; }
        IUserRepository UserRepo { get; }

        void Commit();
    }
}
