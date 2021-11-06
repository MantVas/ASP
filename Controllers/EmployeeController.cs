using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcApp2.Models;

namespace MvcApp2.Controllers
{
    
    public class EmployeeController : Controller
    {

        private IEmployeeRepo _employeeRepo;
        public EmployeeController(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return View(_employeeRepo.GetAll());
        }
        public IActionResult Details(int? id)
        {
            return id == null
                ? NotFound()
                : View(_employeeRepo.GetById((int)id));
        }
        public IActionResult Delete(int? id)
        {
            return (id == null || !_employeeRepo.DeleteById(id))
                ? NotFound()
                : RedirectToAction("List");
        }
        public IActionResult Update(int id, string name)
        {
            System.Console.WriteLine("Cont update");
            _employeeRepo.Update(id, name);
            return RedirectToAction("Details", new { id = id });
        }
        public IActionResult Create(string name)
        {
            _employeeRepo.Create(name);
            return RedirectToAction("List");
        }
    }
}
