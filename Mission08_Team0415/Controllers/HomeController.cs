// Authors: Nya Croft, Noah Hicks, Noah Hasket, Jensen Hermansen
// Section 004

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mission08_Team0415.Models;
using System.Diagnostics;
using Task = Mission08_Team0415.Models.Task;

namespace Mission08_Team0415.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;

        public HomeController(ITaskRepository temp)
        {
            _repo = temp;
        }

        // Display matrix with tasks
        public IActionResult Index()
        {
            var tasks = _repo.Tasks.Where(t => !t.Completed).ToList();
            return View(tasks);
        }

        // Display form
        public IActionResult TaskEntry()
        {
            // Send it the viewbag list of categories to use in the dropdown
            ViewBag.Categories = _repo.Categories.ToList();
            return View();
        }


        // Add Task
        [HttpPost]
        public IActionResult AddTask(Task task)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(task);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _repo.Categories.ToList();
            return View("TaskEntry", task);
        }

        // Delete Task
        public IActionResult DeleteTask(int id)
        {
            _repo.DeleteTask(id);
            return RedirectToAction("Index");
        }

        // Edit Task
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = _repo.GetTask(id.Value);
            if (task == null)
            {
                return NotFound();
            }

            // Fetch categories and assign to ViewBag
            ViewBag.Categories = _repo.Categories.ToList();
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("TaskID,TaskName,TaskDate,Quadrant,CategoryId,Completed")] Task task)
        {
            if (id != task.TaskID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repo.UpdateTask(task);
                return RedirectToAction(nameof(Index));
            }

            // Fetch categories and assign to ViewBag
            ViewBag.Categories = new SelectList(_repo.Categories, "CategoryId", "CategoryName", task.CategoryId);
            return View(task);
        }
    }
}
