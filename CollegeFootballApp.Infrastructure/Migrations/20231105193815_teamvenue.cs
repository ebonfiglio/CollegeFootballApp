using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeFootballApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class teamvenue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Venues_Id",
                table: "Teams");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Venues_Id",
                table: "Teams",
                column: "Id",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
