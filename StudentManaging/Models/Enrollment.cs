    namespace StudentManaging.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        
        public int CourseId { get; set; }
        
        public string? FinalGrade { get; set; }
    }
}