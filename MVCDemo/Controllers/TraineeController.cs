using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class TraineeController : Controller
    {
        DBEntity context = new DBEntity();
        public IActionResult Index()
        {
            List<Trainee> trainees = context.Trainee.Include(e => e.Department).ToList();

            return View(trainees);
        }
    }
}
