using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallbreakApp.Migrations
{
    /// <inheritdoc />
    public partial class AddRoundScores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoundScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoundId = table.Column<int>(type: "int", nullable: false),
                    PlayerSessionId = table.Column<int>(type: "int", nullable: false),
                    Bid = table.Column<int>(type: "int", nullable: false),
                    Tricks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoundScores_PlayerSessions_PlayerSessionId",
                        column: x => x.PlayerSessionId,
                        principalTable: "PlayerSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoundScores_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RoundScores_PlayerSessionId",
                table: "RoundScores",
                column: "PlayerSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundScores_RoundId",
                table: "RoundScores",
                column: "RoundId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoundScores");
        }
    }
}
