using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class EmployeeController : Controller
    {
        DBEntity context = new DBEntity();

        public IActionResult Index()
        {
            //ViewData["Title"] = "Ice";
            //ViewData["factory"] = "Ice";
            //ViewBag.No = 1;
            List<Employee> EmployeesModel = context.Employee.Include(e => e.Department).ToList();
            
            return View(EmployeesModel);
        }

        public IActionResult Create()
        {
            ViewBag.all_departments = context.Department.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (emp != null)
            {
                emp.Department = context.Department.FirstOrDefault(e => e.Id == emp.DeptId);
                
                context.Employee.Add(emp);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", emp);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.all_departments = context.Department.ToList();
            Employee employee = context.Employee.FirstOrDefault(e => e.Id == id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            if (emp != null)
            {
                //Employee employee = context.Employee.FirstOrDefault(e => e.Id == emp.Id);
                Employee employee = context.Employee.Find(emp.Id);
                
                employee.Name = emp.Name;
                employee.Salary = emp.Salary;
                employee.Address = emp.Address;
                employee.Image = emp.Image;
                employee.Position = emp.Position;
                employee.Age = emp.Age;
                employee.DeptId = emp.DeptId;
                
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", emp);
        }

        public ActionResult Search(string Name)
        {
            if(Name.IsNullOrEmpty())
                return RedirectToAction("Index");

            List<Employee> employees = context.Employee.Where(e =>  e.Name.Contains(Name)).Include(e => e.Department).ToList();
            return View("Index" , employees);
            
        }

        public ActionResult Delete(int id)
        {
            Employee emp = context.Employee.Find(id);
            if (emp != null)
            {
                context.Employee.Remove(emp);
                context.SaveChanges(true);
            }
            return RedirectToAction("Index");
        }
    }
}
