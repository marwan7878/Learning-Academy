using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class DepartmentController : Controller
    {
        DBEntity context = new DBEntity();
        public IActionResult EmpOfDept()
        {
            List<Department> depts = context.Department.ToList();
            return View(depts);
        }
        public IActionResult getEmployees(int deptId)
        {
			List<Employee> emps = context.Employee.Where(e=>e.DeptId == deptId).ToList();
			return Json(emps);
        }
    }
}
