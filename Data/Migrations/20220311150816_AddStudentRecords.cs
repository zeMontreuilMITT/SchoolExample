using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolExample.Data.Migrations
{
    public partial class AddStudentRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AverageGrade",
                table: "Courses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "StudentRecordId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentRecords", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StudentRecordId",
                table: "AspNetUsers",
                column: "StudentRecordId",
                unique: true,
                filter: "[StudentRecordId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_StudentRecords_StudentRecordId",
                table: "AspNetUsers",
                column: "StudentRecordId",
                principalTable: "StudentRecords",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_StudentRecords_StudentRecordId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "StudentRecords");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StudentRecordId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AverageGrade",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StudentRecordId",
                table: "AspNetUsers");
        }
    }
}
