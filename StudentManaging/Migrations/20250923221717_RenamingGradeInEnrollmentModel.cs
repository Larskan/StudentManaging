using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManaging.Migrations
{
    /// <inheritdoc />
    public partial class RenamingGradeInEnrollmentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Grade",
                table: "Enrollments",
                newName: "FinalGrade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FinalGrade",
                table: "Enrollments",
                newName: "Grade");
        }
    }
}
