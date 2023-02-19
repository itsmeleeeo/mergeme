using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MergeMe.Migrations
{
    public partial class newDeveloperFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Stack_StacksId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_DeveloperStack_AspNetUsers_developersId",
                table: "DeveloperStack");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StacksId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileImageUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StacksId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserBio",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "developersId",
                table: "DeveloperStack",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.CreateTable(
                name: "Developer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserBio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StacksId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Developer_Stack_StacksId",
                        column: x => x.StacksId,
                        principalTable: "Stack",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Developer_StacksId",
                table: "Developer",
                column: "StacksId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeveloperStack_Developer_developersId",
                table: "DeveloperStack",
                column: "developersId",
                principalTable: "Developer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeveloperStack_Developer_developersId",
                table: "DeveloperStack");

            migrationBuilder.DropTable(
                name: "Developer");

            migrationBuilder.AlterColumn<string>(
                name: "developersId",
                table: "DeveloperStack",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StacksId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserBio",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StacksId",
                table: "AspNetUsers",
                column: "StacksId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Stack_StacksId",
                table: "AspNetUsers",
                column: "StacksId",
                principalTable: "Stack",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeveloperStack_AspNetUsers_developersId",
                table: "DeveloperStack",
                column: "developersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
