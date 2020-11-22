using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeWebUI.Controllers
{
    public class TableController : Controller
    {
        private IManagerService _managerService;
        public TableController(IManagerService managerService)
        {
            _managerService = managerService;
        }
        public IActionResult Index(string query, string sort)
        
        {
            ViewBag.SortIdParameter = string.IsNullOrEmpty(sort) ? "sort_Id" : ""; 
            ViewBag.SortFirstNameParameter = string.IsNullOrEmpty(sort) ? "sort_FirstName" : "";
            ViewBag.SortLastNameParameter = string.IsNullOrEmpty(sort) ? "sort_LastName" : "";
            ViewBag.SortEmailParameter = string.IsNullOrEmpty(sort) ? "sort_Email" : "";
            ViewBag.SortPhoneNumberParameter = string.IsNullOrEmpty(sort) ? "sort_PhoneNumber" : "";

            if (query == null)
            {
                return View(_managerService.Sort(sort));
            }
            
            var search = _managerService.Search(query);
            return View(search);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Manager manager)
        {
            _managerService.Add(manager);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            _managerService.DeleteById(id);
            return RedirectToAction("Index");
        }


        public IActionResult GetById(int id)
        {
            var managerDetails =  _managerService.GetById(id);
            return View("GetById", managerDetails);
        }


        public IActionResult Update(Manager manager)
        {
            _managerService.Update(manager);
            return RedirectToAction("Index");
        }

    }
}
