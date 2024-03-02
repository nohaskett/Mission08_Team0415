// Authors: Nya Croft, Noah Hicks, Noah Hasket, Jensen Hermansen
// Section 004

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("CategoryId")]
        public int ? CategoryId { get; set; }
        public Category ? Category { get; set; }
        [Required]
        public bool Completed { get; set; }
    }
}
