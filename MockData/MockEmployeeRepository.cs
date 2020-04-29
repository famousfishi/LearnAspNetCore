using LearnAspCoreBest.Enums;
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
                new Employee() {Id = 1, Name="Fisayo", Email="oluwayemifisayo@gmail.com", Department=Dept.HR},
                new Employee() {Id = 2, Name="Favour", Email="oluwayemifavour@gmail.com", Department=Dept.IT},
                new Employee() {Id = 3, Name="Nathaniel", Email="oluwayeminathaniel@gmail.com", Department=Dept.Payroll},
                new Employee() {Id = 4, Name="Fayo", Email="oluwayemifayo@gmail.com", Department=Dept.None},


            };

        }

        public Employee Add(Employee employee)
        {
            //to add the employee last ID
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            //since you are creating / adding to the server, then return the created employee
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == Id);
            if(employee != null)
            {
                _employeeList.Remove(employee);
            }

            return employee;

        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id); 
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeList;
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if(employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Department = employeeChanges.Department;
                employee.Email = employeeChanges.Email;
                
            }
            return employee;
        }
    }
}
