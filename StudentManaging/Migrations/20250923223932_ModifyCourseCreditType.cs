using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManaging.Migrations
{
    /// <inheritdoc />
    public partial class ModifyCourseCreditType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Credits",
                table: "Courses",
                type: "decimal(5, 2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Credits",
                table: "Courses",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(5, 2)",
                oldNullable: true);
        }
    }
}
