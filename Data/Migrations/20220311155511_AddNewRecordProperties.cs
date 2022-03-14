using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolExample.Data.Migrations
{
    public partial class AddNewRecordProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDomestic",
                table: "StudentRecords",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TotalHours",
                table: "StudentRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDomestic",
                table: "StudentRecords");

            migrationBuilder.DropColumn(
                name: "TotalHours",
                table: "StudentRecords");
        }
    }
}
