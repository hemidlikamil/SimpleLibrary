using SimpleLibrary.Models;
using SimpleLibrary.Uow;
using SimpleLibrary.ViewModels;

namespace SimpleLibrary.Services
{
    public class EmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(EmployeeViewModel model)
        {
            var employee = new Employee
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age.Value,
                Salary = model.Salary.Value
            };
            if (model.Id == 0)
            {
                _unitOfWork.EmployeeRepo.Add(employee);
            }
            else
            {
                employee.Id = model.Id;
                _unitOfWork.EmployeeRepo.Update(employee);
            }

            _unitOfWork.Commit();
        }

        public Employee GetById(int id)
        {
            return _unitOfWork.EmployeeRepo.GetById(id);
        }
    }
}