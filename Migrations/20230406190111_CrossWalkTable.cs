using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MergeMe.Migrations
{
    public partial class CrossWalkTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_match_Recruiter_recruiterId",
                table: "match");

            migrationBuilder.DropIndex(
                name: "IX_match_recruiterId",
                table: "match");

            migrationBuilder.DropColumn(
                name: "recruiterId",
                table: "match");

            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "Recruiter",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DeveloperRecruiter",
                columns: table => new
                {
                    developersId = table.Column<int>(type: "int", nullable: false),
                    recruitersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperRecruiter", x => new { x.developersId, x.recruitersId });
                    table.ForeignKey(
                        name: "FK_DeveloperRecruiter_Developer_developersId",
                        column: x => x.developersId,
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperRecruiter_Recruiter_recruitersId",
                        column: x => x.recruitersId,
                        principalTable: "Recruiter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recruiter_MatchId",
                table: "Recruiter",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperRecruiter_recruitersId",
                table: "DeveloperRecruiter",
                column: "recruitersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recruiter_match_MatchId",
                table: "Recruiter",
                column: "MatchId",
                principalTable: "match",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recruiter_match_MatchId",
                table: "Recruiter");

            migrationBuilder.DropTable(
                name: "DeveloperRecruiter");

            migrationBuilder.DropIndex(
                name: "IX_Recruiter_MatchId",
                table: "Recruiter");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "Recruiter");

            migrationBuilder.AddColumn<int>(
                name: "recruiterId",
                table: "match",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_match_recruiterId",
                table: "match",
                column: "recruiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_match_Recruiter_recruiterId",
                table: "match",
                column: "recruiterId",
                principalTable: "Recruiter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
