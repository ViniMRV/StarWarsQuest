﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWarsQuest.Api.Migrations
{
    /// <inheritdoc />
    public partial class PlanetDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "planets",
                type: "jsonb",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "planets");
        }
    }
}
