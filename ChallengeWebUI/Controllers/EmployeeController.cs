using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeWebUI.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetByManagerId(int id, string query, string sort)
        {
            ViewBag.SortIdParameter = string.IsNullOrEmpty(sort) ? "sort_Id" : "";
            ViewBag.SortFirstNameParameter = string.IsNullOrEmpty(sort) ? "sort_FirstName" : "";
            ViewBag.SortLastNameParameter = string.IsNullOrEmpty(sort) ? "sort_LastName" : "";
            ViewBag.SortEmailParameter = string.IsNullOrEmpty(sort) ? "sort_Email" : "";
            ViewBag.SortSalaryParameter = string.IsNullOrEmpty(sort) ? "sort_Salary" : "";
           
          _employeeService.GetListById(id);
            if (query == null)
            {
                return View(_employeeService.Sort(sort,id));
            }
            else
            {
                return View(_employeeService.Search(query));
            }

      
        }

    }
}
