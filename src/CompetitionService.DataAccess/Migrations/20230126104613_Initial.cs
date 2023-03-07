using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompetitionService.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompetitionBases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusType = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionBases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoefficientGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompetitionBaseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoefficientGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoefficientGroups_CompetitionBases_CompetitionBaseId",
                        column: x => x.CompetitionBaseId,
                        principalTable: "CompetitionBases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionsDota2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompetitionBaseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Team1Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Team2Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Team1KillAmount = table.Column<int>(type: "integer", nullable: false),
                    Team2KillAmount = table.Column<int>(type: "integer", nullable: false),
                    TotalTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionsDota2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetitionsDota2_CompetitionBases_CompetitionBaseId",
                        column: x => x.CompetitionBaseId,
                        principalTable: "CompetitionBases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coefficients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CoefficientGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Rate = table.Column<double>(type: "double precision", nullable: false),
                    StatusType = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    Probability = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coefficients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coefficients_CoefficientGroups_CoefficientGroupId",
                        column: x => x.CoefficientGroupId,
                        principalTable: "CoefficientGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoefficientGroups_CompetitionBaseId",
                table: "CoefficientGroups",
                column: "CompetitionBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Coefficients_CoefficientGroupId",
                table: "Coefficients",
                column: "CoefficientGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionsDota2_CompetitionBaseId",
                table: "CompetitionsDota2",
                column: "CompetitionBaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coefficients");

            migrationBuilder.DropTable(
                name: "CompetitionsDota2");

            migrationBuilder.DropTable(
                name: "CoefficientGroups");

            migrationBuilder.DropTable(
                name: "CompetitionBases");
        }
    }
}
