using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolExample.Data.Migrations
{
    public partial class AddStudentRecordsWOutDependantId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_StudentRecords_StudentRecordId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StudentRecordId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudentRecordId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "StudentRecords",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRecords_UserId",
                table: "StudentRecords",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRecords_AspNetUsers_UserId",
                table: "StudentRecords",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentRecords_AspNetUsers_UserId",
                table: "StudentRecords");

            migrationBuilder.DropIndex(
                name: "IX_StudentRecords_UserId",
                table: "StudentRecords");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "StudentRecords",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "StudentRecordId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

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
    }
}
