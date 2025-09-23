using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManaging.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        // Sqlite does not support decimal, so we specify precision and scale for other DBs
        [Column(TypeName = "decimal(5, 2)")]
        public decimal? Credits { get; set; }
        public int InstructorId { get; set; } // Foreign key to Instructor
        public Instructor? Instructor { get; set; } // Navigation property to Instructor


        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}