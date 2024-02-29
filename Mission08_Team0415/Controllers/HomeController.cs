using Microsoft.AspNetCore.Mvc;
using Mission08_Team0415.Models;

//using Mission08_Team0415.Models;
using System.Diagnostics;

namespace Mission08_Team0415.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Consolidated constructor
        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TaskEntry()
        {
            return View();
        }
    }
}
