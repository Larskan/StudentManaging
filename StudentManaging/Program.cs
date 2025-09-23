using StudentManaging.Data;
using StudentManaging.Models;

// Bootstrap mechanism.

// Scoped instance of EF Core Database, to interact with SQLite DB. 
// using ensures disposal of context when done.
using (var context = new SMDBContext())
{
    // Ensure database is created and apply migrations if any
    context.Database.EnsureCreated();

    if (!context.Students.Any())
    {
        var student1 = new Student
        {
            FirstName = "Lars",
            MiddleName = "Mikkel",
            LastName = "Hein",
            DateOfBirth = new DateTime(2000, 1, 1),
            Email = "lars.hein@example.com",
            EnrollmentDate = DateTime.Now
        };

        context.Students.Add(student1);
        context.SaveChanges();

        Console.WriteLine($"Added student: {student1.FirstName} {student1.LastName}");
    }
    else
    {
        var student = context.Students.First();
        context.SaveChanges();
        Console.WriteLine($"First student in database: {student.FirstName} {student.LastName}");
    }
}
