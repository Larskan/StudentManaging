namespace StudentManaging.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? Credits { get; set; }
        public int InstructorId { get; set; } // Foreign key to Instructor
        public Instructor? Instructor { get; set; } // Navigation property to Instructor


        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}