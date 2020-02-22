using Microsoft.Ajax.Utilities;
using SimpleLibrary.Models;
using SimpleLibrary.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SimpleLibrary.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<EmployeeViewModel> GetAll(string query = null)
        {
            var emps = !query.IsNullOrWhiteSpace()
                ? _context.Employees.Where(e => e.FirstName.Contains(query)).ToList()
                : _context.Employees.ToList();

            return emps.Select(e => new EmployeeViewModel
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Age = e.Age,
                Salary = e.Salary
            }).ToList();
        }

        public Employee GetById(int id)
        {
            return _context.Employees.Find(id);
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            _context.Employees.Attach(employee);
            _context.Entry(employee).State = EntityState.Modified;
        }

        public void Delete(Employee employee)
        {
            //_context.Employees.Attach(employee);
            _context.Employees.Remove(employee);
        }
    }
}