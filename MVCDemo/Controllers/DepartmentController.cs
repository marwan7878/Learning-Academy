using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;
using MVCDemo.Repositories;

namespace MVCDemo.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentRepository repositoryDepartment;

        public DepartmentController(IDepartmentRepository _repositoryDepartment)
        {
            repositoryDepartment = _repositoryDepartment;

		}
        public IActionResult EmpOfDept()
        {
            ViewBag.ID = repositoryDepartment.ID;
            return View(repositoryDepartment.GetAll());
        }
    }
}
