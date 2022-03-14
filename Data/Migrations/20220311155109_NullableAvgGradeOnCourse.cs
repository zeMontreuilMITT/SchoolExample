using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolExample.Data.Migrations
{
    public partial class NullableAvgGradeOnCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "AverageGrade",
                table: "Courses",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "AverageGrade",
                table: "Courses",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
