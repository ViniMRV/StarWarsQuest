using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace StarWarsQuest.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "characters",
                columns: table => new
                {
                    characterid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_characters", x => x.characterid);
                });

            migrationBuilder.CreateTable(
                name: "quests",
                columns: table => new
                {
                    questid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    started = table.Column<bool>(type: "boolean", nullable: false),
                    ended = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quests", x => x.questid);
                });

            migrationBuilder.CreateTable(
                name: "spaceships",
                columns: table => new
                {
                    spaceshipid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spaceships", x => x.spaceshipid);
                });

            migrationBuilder.CreateTable(
                name: "questassociations",
                columns: table => new
                {
                    characterid = table.Column<int>(type: "integer", nullable: false),
                    questid = table.Column<int>(type: "integer", nullable: false),
                    spaceshipid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questassociations", x => new { x.characterid, x.questid, x.spaceshipid });
                    table.ForeignKey(
                        name: "FK_questassociations_characters_characterid",
                        column: x => x.characterid,
                        principalTable: "characters",
                        principalColumn: "characterid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_questassociations_quests_questid",
                        column: x => x.questid,
                        principalTable: "quests",
                        principalColumn: "questid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_questassociations_spaceships_spaceshipid",
                        column: x => x.spaceshipid,
                        principalTable: "spaceships",
                        principalColumn: "spaceshipid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_questassociations_questid",
                table: "questassociations",
                column: "questid");

            migrationBuilder.CreateIndex(
                name: "IX_questassociations_spaceshipid",
                table: "questassociations",
                column: "spaceshipid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "questassociations");

            migrationBuilder.DropTable(
                name: "characters");

            migrationBuilder.DropTable(
                name: "quests");

            migrationBuilder.DropTable(
                name: "spaceships");
        }
    }
}
