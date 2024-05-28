using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCDemo.Models;
using MVCDemo.ViewModels;

namespace MVCDemo.Controllers
{
    public class InstructorController : Controller
    {
        DBEntity context = new DBEntity();
        public IActionResult Index()
        {
            List<Course> courses = context.Course.Include(e => e.Department).ToList();
            
            var s = courses[0].Department.Name;
            List<Instructor> instructors = context.Instructor.ToList();
            List<InstructorViewModel> InstructorsVM = new List<InstructorViewModel>();
            InstructorViewModel InstructorsV = new InstructorViewModel();
            InstructorsV.Course_Name = instructors[0].Department.Name;
            for(int i = 0; i <  instructors.Count; i++)
            {
                InstructorsVM.Add(new InstructorViewModel(instructors[i].Name , instructors[i].Image
                    , instructors[i].Salary, instructors[i].Address));
            }
            return View(InstructorsVM);
        }
    }
}
