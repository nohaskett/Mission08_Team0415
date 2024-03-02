// Authors: Nya Croft, Noah Hicks, Noah Hasket, Jensen Hermansen
// Section 004

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0415.Models
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Task> Tasks { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School"},
                new Category { CategoryId = 3, CategoryName = "Work"},
                new Category { CategoryId = 4, CategoryName = "Church"}

            );
        }
    }   
}
