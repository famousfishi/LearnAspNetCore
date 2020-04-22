using LearnAspCoreBest.InterfaceRepositories;
using LearnAspCoreBest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAspCoreBest.MockData
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new  List<Employee>()
            {
                new Employee() {Id = 1, Name="Fisayo", Email="oluwayemifisayo@gmail.com", Department="CSC"},
                new Employee() {Id = 2, Name="Favour", Email="oluwayemifavour@gmail.com", Department="CSE"},
                new Employee() {Id = 3, Name="Nathaniel", Email="oluwayeminathaniel@gmail.com", Department="CSX"},
                new Employee() {Id = 4, Name="Fayo", Email="oluwayemifayo@gmail.com", Department="CSD"},


            };

        }
        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id); 
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeList;
        }
    }
}
