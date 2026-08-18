using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using mvc.Models;

namespace mvc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ITIContext _context;

        public EmployeeController(ITIContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveCreate(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        [HttpPost]
        public IActionResult SaveEdit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(employee);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        [HttpPost]
        public IActionResult SaveDelete(Employee employee)
        {
            var emp = _context.Employees.Find(employee.Id);

            if (emp == null)
                return NotFound();

            _context.Employees.Remove(emp);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}