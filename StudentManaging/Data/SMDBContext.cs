using Microsoft.EntityFrameworkCore;
using StudentManaging.Models;

namespace StudentManaging.Data
{
    public class SMDBContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=StudentManaging.db");
        }
    } 
}