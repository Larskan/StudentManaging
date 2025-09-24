namespace StudentManaging.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Email { get; set; }

        public DateTime? EnrollmentDate { get; set; }

        // Represents the one-to-many relationship with Enrollment
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}