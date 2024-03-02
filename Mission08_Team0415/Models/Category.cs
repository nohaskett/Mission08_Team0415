// Authors: Nya Croft, Noah Hicks, Noah Hasket, Jensen Hermansen
// Section 004

using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0415.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
