using SimpleLibrary.Models;
using SimpleLibrary.ViewModels;
using System.Collections.Generic;

namespace SimpleLibrary.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeViewModel> GetAll(string query = null);
        Employee GetById(int id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
    }
}
