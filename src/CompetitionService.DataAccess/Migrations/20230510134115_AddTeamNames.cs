using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompetitionService.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Team1Name",
                table: "CompetitionsDota2",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Team2Name",
                table: "CompetitionsDota2",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Team1Name",
                table: "CompetitionsDota2");

            migrationBuilder.DropColumn(
                name: "Team2Name",
                table: "CompetitionsDota2");
        }
    }
}
