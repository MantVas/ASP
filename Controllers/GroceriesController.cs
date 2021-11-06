using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcApp2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApp2.Controllers
{
    [Authorize]
    public class GroceriesController : Controller
    {
        private IGroceriesRepo _groceriesRepo;
        public GroceriesController(IGroceriesRepo groceriesRepo)
        {
            _groceriesRepo = groceriesRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return View(_groceriesRepo.GetAll());
        }
        public IActionResult Details(int? id)
        {
            return id == null
                ? NotFound()
                : View(_groceriesRepo.GetById((int)id));
        }
        public IActionResult Delete(int? id)
        {
            return (id == null || !_groceriesRepo.DeleteById(id))
                ? NotFound()
                : RedirectToAction("List");
        }
        public IActionResult Update(int id, string name)
        {
            System.Console.WriteLine("Cont update");
            _groceriesRepo.Update(id, name);
            return RedirectToAction("Details", new { id = id });
        }
        public IActionResult Create(string name)
        {
            _groceriesRepo.Create(name);
            return RedirectToAction("List");
        }
    }
}
