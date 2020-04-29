using LearnAspCoreBest.InterfaceRepositories;
using LearnAspCoreBest.Models;
using LearnAspCoreBest.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAspCoreBest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        

        public ViewResult Index()
        {
            var model = _employeeRepository.GetEmployees();
            return View(model);

        } 

     
        //can use JsonResult if we are building an API
        public ViewResult Details(int id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(id),
                PageTitle = "Employee Detailsss"
            };
            return View(homeDetailsViewModel);
        }

        //get Create View
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        //post create view
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepository.Add(employee);
                return RedirectToAction("Details", new { id = employee.Id });
            }
            return View();
        }



    }
}
