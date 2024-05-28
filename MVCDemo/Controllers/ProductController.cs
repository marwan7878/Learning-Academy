using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View(ProductBL.getAll());
        }
        public IActionResult Details(int id)
        {
            Product product = ProductBL.getAll().FirstOrDefault(s => s.Id == id);
            return View("Details",product);
        }
    }
}
