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
        private readonly ILeadRepository _leadRepository;

        public HomeController(IEmployeeRepository employeeRepository, ILeadRepository leadRepository)
        {
            _employeeRepository = employeeRepository;
            _leadRepository = leadRepository;
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


        public int Index3()
        {
            return _leadRepository.GetLeads(1).Age;
        }

    }
}
