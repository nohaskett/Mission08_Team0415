﻿using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0415.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
