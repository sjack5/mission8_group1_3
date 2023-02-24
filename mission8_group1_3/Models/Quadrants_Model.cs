using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mission8_group1_3.Models
{
    public class Quadrants_Model
    {
        [Key]
        [Required]
        public int taskId { get; set; }
        public DateTime dueDate { get; set; }
        [Required]
        public string Quadrant { get; set; }
        public bool Completed { get; set; }

        //Building Foreign Key Relationship
        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; } 
        

    }
}
