using CRUD_ASP.Context;
using CRUD_ASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_ASP.Controllers
{
    public class EmployeeController : Controller
    {
        private MYContext MYContext;

        public EmployeeController(MYContext mYContext)
        {
            this.MYContext = mYContext;
        }

        public IActionResult Create() 
        {
            ViewBag.Message = TempData["Message"];

            return View();
        }

        [HttpPost] // POST METHOD
        [ValidateAntiForgeryToken] // Add CSRF
        public IActionResult Store(Employee employeeRequest) 
        {
            var employee = new Employee()
            {
                Id = employeeRequest.Id,
                Name = employeeRequest.Name,
                Email = employeeRequest.Email,
                Address = employeeRequest.Address,
                Salary = employeeRequest.Salary,
                BirthDate = employeeRequest.BirthDate,
            };

            // Use Entity Framework
            MYContext.Employees.Add(employee);
            MYContext.SaveChanges();

            // Temporary date for message flash
            TempData["Message"] = "Employee saved successfully";

            return RedirectToAction("Index", "Home", new { message = TempData["Message"] });
        }

        [HttpPost("{id:int}")] // DELETE METHOD
        [ValidateAntiForgeryToken] // Add CSRF
        public IActionResult Destroy(int id)
        {
            var employee = MYContext.Employees.Find(id); // Get employee from database using ID

            // Check If employee is found
            if (employee != null)
            {
                MYContext.Employees.Remove(employee); // Delete
                MYContext.SaveChanges(); // Save
                TempData["Message"] = "Employee deleted successfully";
            }
            else
            {
                TempData["Message"] = "Employee not found";
            }

            // Redirect to INDEX method of HomeController
            return RedirectToAction("Index", "Home", new { message = TempData["Message"] });

        }
    }
}
