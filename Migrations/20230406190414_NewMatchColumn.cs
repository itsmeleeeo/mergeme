using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MergeMe.Migrations
{
    public partial class NewMatchColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_match_Developer_developerId",
                table: "match");

            migrationBuilder.DropIndex(
                name: "IX_match_developerId",
                table: "match");

            migrationBuilder.DropColumn(
                name: "developerId",
                table: "match");

            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "Developer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Developer_MatchId",
                table: "Developer",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Developer_match_MatchId",
                table: "Developer",
                column: "MatchId",
                principalTable: "match",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developer_match_MatchId",
                table: "Developer");

            migrationBuilder.DropIndex(
                name: "IX_Developer_MatchId",
                table: "Developer");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "Developer");

            migrationBuilder.AddColumn<int>(
                name: "developerId",
                table: "match",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_match_developerId",
                table: "match",
                column: "developerId");

            migrationBuilder.AddForeignKey(
                name: "FK_match_Developer_developerId",
                table: "match",
                column: "developerId",
                principalTable: "Developer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
