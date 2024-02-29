using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;


namespace Mission08_Team0415.Models
{
    public class Task
    {
        [Key]
        [Required]

        public int TaskID { get; set; }
        [Required]
        public string ? TaskName { get; set; }

        [Required]
        public int ? DueDate { get; set; }

        [Required]
        public int ? Quadrant { get; set; }

        [Required]
        public string ? Area { get; set; }

        [Required]
        public bool ? Completed { get; set; }

    }
}
