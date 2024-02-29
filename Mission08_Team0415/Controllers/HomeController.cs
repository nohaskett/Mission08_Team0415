using Microsoft.AspNetCore.Mvc;
using Mission08_Team0415.Models;

//using Mission08_Team0415.Models;
using System.Diagnostics;
using Task = Mission08_Team0415.Models.Task;

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
            var task = _context.Tasks.ToList();

            return View(task);
        }

        public IActionResult TaskEntry()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("TaskEntry");
        }
    }
}
