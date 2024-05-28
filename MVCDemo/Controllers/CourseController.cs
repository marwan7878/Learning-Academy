using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class CourseController : Controller
    {
        DBEntity context = new DBEntity();
        public IActionResult Index()
        {
            return View(context.Course.Include(e=>e.Department).ToList());
        }
        public IActionResult Create()
        {
            ViewBag.all_departments = context.Department.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    context.Course.Add(course);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.InnerException.Message);
                }
            }

            ViewBag.all_departments = context.Department.ToList();
            return View(course);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.all_departments = context.Department.ToList();
            return View(context.Course.FirstOrDefault(e=>e.Id == id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course course)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    Course crs = context.Course.FirstOrDefault(e => e.Id == course.Id);
                    crs.Name = course.Name;
                    crs.Degree = course.Degree;
                    crs.MinDegree = course.MinDegree;
                    crs.Dept_Id = course.Dept_Id;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.InnerException.Message);
                }
            }
            ViewBag.all_departments = context.Department.ToList();
            return View();
        }
        public IActionResult TestMinDegree(int minDegree , int Degree)
        {
            if(minDegree > 0 && minDegree < Degree)
            {
                return Json(true);
            }
            return Json(false);
        }
        public IActionResult TestID(int Dept_Id)
        {
            if(Dept_Id > 0 )
            {
                return Json(true);
            }
            return Json(false);
        }
        public ActionResult Delete(int id)
        {
            Course crs = context.Course.Find(id);
            if (crs != null)
            {
                context.Course.Remove(crs);
                context.SaveChanges(true);
            }
            return RedirectToAction("Index");
        }
    }
}
