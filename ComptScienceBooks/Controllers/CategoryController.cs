using Microsoft.AspNetCore.Mvc;

namespace ComptScienceBooks.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Artificial()
        {
            return View();
        }
        public IActionResult Machine()
        {
            return View();
        }
        public IActionResult Programming()
        {
            return View();
        }
        public IActionResult Security()
        {
            return View();
        }
        public IActionResult Software()
        {
            return View();
        }
    }
}
