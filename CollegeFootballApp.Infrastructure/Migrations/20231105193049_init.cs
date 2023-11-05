using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeFootballApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conferences",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timezone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<float>(type: "real", nullable: true),
                    Longitude = table.Column<float>(type: "real", nullable: true),
                    Elevation = table.Column<float>(type: "real", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: true),
                    YearConstructed = table.Column<int>(type: "int", nullable: true),
                    Grass = table.Column<bool>(type: "bit", nullable: true),
                    Dome = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mascot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltName3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Venues_Id",
                        column: x => x.Id,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamConferences",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    ConferenceName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamConferences", x => new { x.TeamId, x.ConferenceName });
                    table.ForeignKey(
                        name: "FK_TeamConferences_Conferences_ConferenceName",
                        column: x => x.ConferenceName,
                        principalTable: "Conferences",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamConferences_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Season = table.Column<int>(type: "int", nullable: false),
                    Week = table.Column<int>(type: "int", nullable: false),
                    SeasonType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartTimeTbd = table.Column<bool>(type: "bit", nullable: true),
                    Completed = table.Column<bool>(type: "bit", nullable: true),
                    NeutralSite = table.Column<bool>(type: "bit", nullable: true),
                    ConferenceGame = table.Column<bool>(type: "bit", nullable: true),
                    Attendance = table.Column<int>(type: "int", nullable: true),
                    VenueId = table.Column<int>(type: "int", nullable: false),
                    HomeId = table.Column<int>(type: "int", nullable: false),
                    HomeConferenceName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AwayTeamId = table.Column<int>(type: "int", nullable: false),
                    AwayConferenceName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExcitementIndex = table.Column<float>(type: "real", nullable: true),
                    Highlights = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_TeamConferences_AwayTeamId_AwayConferenceName",
                        columns: x => new { x.AwayTeamId, x.AwayConferenceName },
                        principalTable: "TeamConferences",
                        principalColumns: new[] { "TeamId", "ConferenceName" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_TeamConferences_HomeId_HomeConferenceName",
                        columns: x => new { x.HomeId, x.HomeConferenceName },
                        principalTable: "TeamConferences",
                        principalColumns: new[] { "TeamId", "ConferenceName" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_AwayTeamId_AwayConferenceName",
                table: "Games",
                columns: new[] { "AwayTeamId", "AwayConferenceName" });

            migrationBuilder.CreateIndex(
                name: "IX_Games_HomeId_HomeConferenceName",
                table: "Games",
                columns: new[] { "HomeId", "HomeConferenceName" });

            migrationBuilder.CreateIndex(
                name: "IX_Games_VenueId",
                table: "Games",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamConferences_ConferenceName",
                table: "TeamConferences",
                column: "ConferenceName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "TeamConferences");

            migrationBuilder.DropTable(
                name: "Conferences");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
