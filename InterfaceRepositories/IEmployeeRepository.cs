using LearnAspCoreBest.Models;
using System.Collections.Generic;

namespace LearnAspCoreBest.InterfaceRepositories
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);

        IEnumerable<Employee> GetEmployees();

        Employee Add(Employee employee);

        Employee Update(Employee employeeChanges);

        Employee Delete(int Id);
    }
}