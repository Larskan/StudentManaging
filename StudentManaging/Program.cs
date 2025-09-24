using StudentManaging.Data;
using Microsoft.EntityFrameworkCore;

// This program is just a checker that the database can be created and migrations applied.
// In a real application, you would have more logic here to interact with the user.

Console.WriteLine("Starting Student Managing Application...");

using (var context = new SMDBContext())
{
    // Apply any pending migrations automatically
    context.Database.Migrate();

    // Get the last applied migration
    var lastMigration = context.Database.GetAppliedMigrations().LastOrDefault();
    Console.WriteLine($"Database is up-to-date with latest migrations. Latest Migration applies: {lastMigration}");
}

// Result from dotnet run:
// Database is up-to-date with latest migrations. Latest Migration applies: 20250923223932_ModifyCourseCreditType