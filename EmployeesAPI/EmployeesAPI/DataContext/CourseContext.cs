using EmployeesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAPI.DataContext
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options):base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
