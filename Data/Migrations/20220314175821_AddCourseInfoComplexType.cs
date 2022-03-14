using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolExample.Data.Migrations
{
    public partial class AddCourseInfoComplexType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseInfoId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CourseInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternationalDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DomesticDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseIntroduction = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseInfoId",
                table: "Courses",
                column: "CourseInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseInfo_CourseInfoId",
                table: "Courses",
                column: "CourseInfoId",
                principalTable: "CourseInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseInfo_CourseInfoId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "CourseInfo");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseInfoId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseInfoId",
                table: "Courses");
        }
    }
}
