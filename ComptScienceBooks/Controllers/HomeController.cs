using Microsoft.AspNetCore.Mvc;

namespace ComptScienceBooks.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        
    }
}
