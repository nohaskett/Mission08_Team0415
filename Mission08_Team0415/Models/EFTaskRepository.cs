// Authors: Nya Croft, Noah Hicks, Noah Hasket, Jensen Hermansen
// Section 004

using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0415.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private ApplicationDbContext _context;

        public EFTaskRepository(ApplicationDbContext temp)
        {
            _context = temp;
        }

        public List<Task> Tasks => _context.Tasks.ToList();
        public List<Category> Categories => _context.Categories.ToList();

        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(int taskId)
        {
            var task = _context.Tasks.Find(taskId);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        public Task GetTask(int id)
        {
            return _context.Tasks.FirstOrDefault(x => x.TaskID == id);
        }

        public List<Task> GetAllTasks()
        {
            return _context.Tasks
                .Include(x => x.Category).ToList();
        }
    }
}
