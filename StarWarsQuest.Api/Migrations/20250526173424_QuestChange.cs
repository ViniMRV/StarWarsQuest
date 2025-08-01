using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWarsQuest.Api.Migrations
{
    /// <inheritdoc />
    public partial class QuestChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ended",
                table: "quests");

            migrationBuilder.DropColumn(
                name: "started",
                table: "quests");

            migrationBuilder.AddColumn<DateTime>(
                name: "enddate",
                table: "quests",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "startdate",
                table: "quests",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "quests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "enddate",
                table: "quests");

            migrationBuilder.DropColumn(
                name: "startdate",
                table: "quests");

            migrationBuilder.DropColumn(
                name: "status",
                table: "quests");

            migrationBuilder.AddColumn<bool>(
                name: "ended",
                table: "quests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "started",
                table: "quests",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
