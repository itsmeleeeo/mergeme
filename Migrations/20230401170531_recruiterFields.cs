using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MergeMe.Migrations
{
    public partial class recruiterFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Recruiter");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Developer");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Recruiter",
                newName: "CompanyName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Recruiter",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Recruiter",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Developer",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }
    }
}
