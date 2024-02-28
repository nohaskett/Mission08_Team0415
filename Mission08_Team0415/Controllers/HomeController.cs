using Microsoft.AspNetCore.Mvc;
//using Mission08_Team0415.Models;
using System.Diagnostics;

namespace Mission08_Team0415.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
