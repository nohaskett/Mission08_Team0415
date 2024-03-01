using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var task = _context.Tasks
                .Where(t => !t.Completed)
                .ToList();

            return View(task);
        }

        public IActionResult TaskEntry()
        {
            // Send it the viewbag list of categories to use in the dropdown
            ViewBag.Categories = _context.Categories.ToList();
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

        [HttpPost]
        public IActionResult DeleteTask(int id)
        {
            var movie = _context.Tasks.Find(id);
            if (movie != null)
            {
                _context.Tasks.Remove(movie);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            // Fetch categories and assign to ViewBag
            ViewBag.Categories = _context.Categories.ToList();

            return View(task);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskID,TaskName,TaskDate,Quadrant,CategoryId,Completed")] Task task)
        {
            if (id != task.TaskID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            // Fetch categories and assign to ViewBag
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName", task.CategoryId);

            return View(task);
        }
    }
}
