using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MergeMe.Migrations
{
    public partial class RemovingFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeveloperStack_Stack_stacksId",
                table: "DeveloperStack");

            migrationBuilder.DropForeignKey(
                name: "FK_RecruiterStack_Stack_stacksId",
                table: "RecruiterStack");

            migrationBuilder.DropIndex(
                name: "IX_RecruiterStack_stacksId",
                table: "RecruiterStack");

            migrationBuilder.DropIndex(
                name: "IX_DeveloperStack_stacksId",
                table: "DeveloperStack");

            migrationBuilder.DropColumn(
                name: "stacksId",
                table: "RecruiterStack");

            migrationBuilder.DropColumn(
                name: "stacksId",
                table: "DeveloperStack");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "stacksId",
                table: "RecruiterStack",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "stacksId",
                table: "DeveloperStack",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RecruiterStack_stacksId",
                table: "RecruiterStack",
                column: "stacksId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperStack_stacksId",
                table: "DeveloperStack",
                column: "stacksId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeveloperStack_Stack_stacksId",
                table: "DeveloperStack",
                column: "stacksId",
                principalTable: "Stack",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecruiterStack_Stack_stacksId",
                table: "RecruiterStack",
                column: "stacksId",
                principalTable: "Stack",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
