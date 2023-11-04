using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeFootballApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class keyfixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_TeamConferences_AwayTeamId_AwayConferenceId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_TeamConferences_HomeTeamId_HomeConferenceId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamConferences_Conferences_ConferenceId",
                table: "TeamConferences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamConferences",
                table: "TeamConferences");

            migrationBuilder.DropIndex(
                name: "IX_TeamConferences_ConferenceId",
                table: "TeamConferences");

            migrationBuilder.DropIndex(
                name: "IX_Games_AwayTeamId_AwayConferenceId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_HomeTeamId_HomeConferenceId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conferences",
                table: "Conferences");

            migrationBuilder.DropColumn(
                name: "ConferenceId",
                table: "TeamConferences");

            migrationBuilder.DropColumn(
                name: "AwayConferenceId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "HomeConferenceId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Conferences");

            migrationBuilder.RenameColumn(
                name: "HomeTeamId",
                table: "Games",
                newName: "HomeId");

            migrationBuilder.AddColumn<string>(
                name: "ConferenceName",
                table: "TeamConferences",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AwayConferenceName",
                table: "Games",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomeConferenceName",
                table: "Games",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Conferences",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamConferences",
                table: "TeamConferences",
                columns: new[] { "TeamId", "ConferenceName" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conferences",
                table: "Conferences",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_TeamConferences_ConferenceName",
                table: "TeamConferences",
                column: "ConferenceName");

            migrationBuilder.CreateIndex(
                name: "IX_Games_AwayTeamId_AwayConferenceName",
                table: "Games",
                columns: new[] { "AwayTeamId", "AwayConferenceName" });

            migrationBuilder.CreateIndex(
                name: "IX_Games_HomeId_HomeConferenceName",
                table: "Games",
                columns: new[] { "HomeId", "HomeConferenceName" });

            migrationBuilder.AddForeignKey(
                name: "FK_Games_TeamConferences_AwayTeamId_AwayConferenceName",
                table: "Games",
                columns: new[] { "AwayTeamId", "AwayConferenceName" },
                principalTable: "TeamConferences",
                principalColumns: new[] { "TeamId", "ConferenceName" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_TeamConferences_HomeId_HomeConferenceName",
                table: "Games",
                columns: new[] { "HomeId", "HomeConferenceName" },
                principalTable: "TeamConferences",
                principalColumns: new[] { "TeamId", "ConferenceName" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamConferences_Conferences_ConferenceName",
                table: "TeamConferences",
                column: "ConferenceName",
                principalTable: "Conferences",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_TeamConferences_AwayTeamId_AwayConferenceName",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_TeamConferences_HomeId_HomeConferenceName",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamConferences_Conferences_ConferenceName",
                table: "TeamConferences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamConferences",
                table: "TeamConferences");

            migrationBuilder.DropIndex(
                name: "IX_TeamConferences_ConferenceName",
                table: "TeamConferences");

            migrationBuilder.DropIndex(
                name: "IX_Games_AwayTeamId_AwayConferenceName",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_HomeId_HomeConferenceName",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conferences",
                table: "Conferences");

            migrationBuilder.DropColumn(
                name: "ConferenceName",
                table: "TeamConferences");

            migrationBuilder.DropColumn(
                name: "AwayConferenceName",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "HomeConferenceName",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "HomeId",
                table: "Games",
                newName: "HomeTeamId");

            migrationBuilder.AddColumn<int>(
                name: "ConferenceId",
                table: "TeamConferences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AwayConferenceId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeConferenceId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Conferences",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Conferences",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamConferences",
                table: "TeamConferences",
                columns: new[] { "TeamId", "ConferenceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conferences",
                table: "Conferences",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TeamConferences_ConferenceId",
                table: "TeamConferences",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_AwayTeamId_AwayConferenceId",
                table: "Games",
                columns: new[] { "AwayTeamId", "AwayConferenceId" });

            migrationBuilder.CreateIndex(
                name: "IX_Games_HomeTeamId_HomeConferenceId",
                table: "Games",
                columns: new[] { "HomeTeamId", "HomeConferenceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Games_TeamConferences_AwayTeamId_AwayConferenceId",
                table: "Games",
                columns: new[] { "AwayTeamId", "AwayConferenceId" },
                principalTable: "TeamConferences",
                principalColumns: new[] { "TeamId", "ConferenceId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_TeamConferences_HomeTeamId_HomeConferenceId",
                table: "Games",
                columns: new[] { "HomeTeamId", "HomeConferenceId" },
                principalTable: "TeamConferences",
                principalColumns: new[] { "TeamId", "ConferenceId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamConferences_Conferences_ConferenceId",
                table: "TeamConferences",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
