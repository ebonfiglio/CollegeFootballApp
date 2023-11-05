using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeFootballApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class unknownconfnamerevert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ConferenceName",
                table: "TeamConferences",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "UNKNOWN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ConferenceName",
                table: "TeamConferences",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "UNKNOWN",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
