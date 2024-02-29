using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0415.Models
{
    public class AddTaskContext : DbContext
    {

        public AddTaskContext(DbContextOptions<AddTaskContext> options) : base(options)
        { 
        }

        public DbSet<Task> Tasks { get; set; }
    }
}
