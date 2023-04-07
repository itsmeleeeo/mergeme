using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MergeMe.Migrations
{
    public partial class DbChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developer_match_MatchId",
                table: "Developer");

            migrationBuilder.DropForeignKey(
                name: "FK_Recruiter_match_MatchId",
                table: "Recruiter");

            migrationBuilder.DropIndex(
                name: "IX_Recruiter_MatchId",
                table: "Recruiter");

            migrationBuilder.DropIndex(
                name: "IX_Developer_MatchId",
                table: "Developer");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "Recruiter");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "Developer");

            migrationBuilder.AddColumn<int>(
                name: "developersId",
                table: "match",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "recruitersId",
                table: "match",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_match_developersId",
                table: "match",
                column: "developersId");

            migrationBuilder.CreateIndex(
                name: "IX_match_recruitersId",
                table: "match",
                column: "recruitersId");

            migrationBuilder.AddForeignKey(
                name: "FK_match_Developer_developersId",
                table: "match",
                column: "developersId",
                principalTable: "Developer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_match_Recruiter_recruitersId",
                table: "match",
                column: "recruitersId",
                principalTable: "Recruiter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_match_Developer_developersId",
                table: "match");

            migrationBuilder.DropForeignKey(
                name: "FK_match_Recruiter_recruitersId",
                table: "match");

            migrationBuilder.DropIndex(
                name: "IX_match_developersId",
                table: "match");

            migrationBuilder.DropIndex(
                name: "IX_match_recruitersId",
                table: "match");

            migrationBuilder.DropColumn(
                name: "developersId",
                table: "match");

            migrationBuilder.DropColumn(
                name: "recruitersId",
                table: "match");

            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "Recruiter",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "Developer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recruiter_MatchId",
                table: "Recruiter",
                column: "MatchId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Recruiter_match_MatchId",
                table: "Recruiter",
                column: "MatchId",
                principalTable: "match",
                principalColumn: "Id");
        }
    }
}
