using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MergeMe.Migrations
{
    public partial class recruitersFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecruiterStack_Recruiter_recruitersId",
                table: "RecruiterStack");

            migrationBuilder.DropTable(
                name: "Recruiter");

            migrationBuilder.AlterColumn<string>(
                name: "recruitersId",
                table: "RecruiterStack",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Developer_FirstName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Developer_LastName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Developer_Password",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Developer_ProfileImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Developer_StacksId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Developer_UserBio",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Developer_StacksId",
                table: "AspNetUsers",
                column: "Developer_StacksId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Stack_Developer_StacksId",
                table: "AspNetUsers",
                column: "Developer_StacksId",
                principalTable: "Stack",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecruiterStack_AspNetUsers_recruitersId",
                table: "RecruiterStack",
                column: "recruitersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Stack_Developer_StacksId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_RecruiterStack_AspNetUsers_recruitersId",
                table: "RecruiterStack");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Developer_StacksId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Developer_FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Developer_LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Developer_Password",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Developer_ProfileImageUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Developer_StacksId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Developer_UserBio",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "recruitersId",
                table: "RecruiterStack",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Recruiter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StacksId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recruiter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recruiter_Stack_StacksId",
                        column: x => x.StacksId,
                        principalTable: "Stack",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recruiter_StacksId",
                table: "Recruiter",
                column: "StacksId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecruiterStack_Recruiter_recruitersId",
                table: "RecruiterStack",
                column: "recruitersId",
                principalTable: "Recruiter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
