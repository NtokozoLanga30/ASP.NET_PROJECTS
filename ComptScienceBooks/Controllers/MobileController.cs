using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComptScienceBooks.Controllers
{
    public class MobileController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
