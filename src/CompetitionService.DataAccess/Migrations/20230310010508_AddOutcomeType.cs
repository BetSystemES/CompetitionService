using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompetitionService.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddOutcomeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OutcomeType",
                table: "Coefficients",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OutcomeType",
                table: "Coefficients");
        }
    }
}
