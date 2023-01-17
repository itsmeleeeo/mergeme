using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MergeMe.Migrations
{
    public partial class ChangingDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Recruiter");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Developer");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Recruiter",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Developer",
                newName: "Password");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Recruiter",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Developer",
                newName: "password");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Recruiter",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Developer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
