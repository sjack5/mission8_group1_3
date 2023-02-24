using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission8_group1_3.Models
{
    public class QuadrantContext :DbContext
    {
        //Constructor
        public QuadrantContext(DbContextOptions<QuadrantContext> options) : base(options)
        {
            //Leave blank for now
        }
        public DbSet<Quadrants_Model> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        //Seed Data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                    new Category { CategoryID = 1, CategoryName = "School" },
                    new Category { CategoryID = 2, CategoryName = "Work" },
                    new Category { CategoryID = 3, CategoryName = "Home" },
                    new Category { CategoryID = 4, CategoryName = "Church" }
            );
        }
    }
}
