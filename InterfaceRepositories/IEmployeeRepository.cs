using LearnAspCoreBest.Models;
using System.Collections.Generic;

namespace LearnAspCoreBest.InterfaceRepositories
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);
        IEnumerable<Employee> GetEmployees();

    }
}