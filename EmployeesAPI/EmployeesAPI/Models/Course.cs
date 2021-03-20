using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAPI.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public decimal CoursePrice { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
