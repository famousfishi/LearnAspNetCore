using LearnAspCoreBest.Data;
using LearnAspCoreBest.InterfaceRepositories;
using LearnAspCoreBest.Models;
using System.Collections.Generic;

namespace LearnAspCoreBest.MockData
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public Employee Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = _context.Employees.Find(Id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return employee;
        }

        public Employee GetEmployee(int Id)
        {
            return _context.Employees.Find(Id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees;
        }

        public Employee Update(Employee employeeChanges)
        {
            var employee = _context.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            //then return the employee object (employeeChanges)
            return employeeChanges;
        }
    }
}