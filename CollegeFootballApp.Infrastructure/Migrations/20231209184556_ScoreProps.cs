using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeFootballApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ScoreProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AwayDivision",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AwayLineScores",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AwayPoints",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AwayPostWinProb",
                table: "Games",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AwayPostgameElo",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AwayPregameElo",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeDivision",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeLineScores",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomePoints",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HomePostWinProb",
                table: "Games",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomePostgameElo",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomePregameElo",
                table: "Games",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwayDivision",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "AwayLineScores",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "AwayPoints",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "AwayPostWinProb",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "AwayPostgameElo",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "AwayPregameElo",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "HomeDivision",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "HomeLineScores",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "HomePoints",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "HomePostWinProb",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "HomePostgameElo",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "HomePregameElo",
                table: "Games");
        }
    }
}
