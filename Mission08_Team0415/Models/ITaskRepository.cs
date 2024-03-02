// Authors: Nya Croft, Noah Hicks, Noah Hasket, Jensen Hermansen
// Section 004

namespace Mission08_Team0415.Models
{
    public interface ITaskRepository
    {
        List<Task> Tasks { get; }
        List<Category> Categories { get; }
        void AddTask(Task task);
        void UpdateTask(Task task);
        void DeleteTask(int taskId);
        Task GetTask(int id);
        List<Task> GetAllTasks();
    }
}
