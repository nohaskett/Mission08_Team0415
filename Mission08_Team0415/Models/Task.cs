using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0415.Models
{
    public class Task
    {
        [Key]
        [Required]
        public int TaskID { get; set; }
        [Required]
        public string TaskName { get; set; }
        public DateOnly? TaskDate { get; set; }
        [Required]
        public string Quadrant { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public bool Completed { get; set; }
    }
}
