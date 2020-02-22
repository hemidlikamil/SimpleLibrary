using SimpleLibrary.Models;
using SimpleLibrary.Uow;

namespace SimpleLibrary.Services
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User FindUserBy(string username, string password)
        {
            return _unitOfWork.UserRepo.GetBy(username, password);
        }

        public bool Register(string username, string password, string confirmPassword)
        {
            if (!string.Equals(password, confirmPassword)) return false;
            var user = _unitOfWork.UserRepo.GetBy(username);
            if (user != null)
            {
                return false;
            }

            user = new User
            {
                Username = username,
                Password = password
            };
            _unitOfWork.UserRepo.Add(user);
            _unitOfWork.Commit();
            return true;
        }
    }
}