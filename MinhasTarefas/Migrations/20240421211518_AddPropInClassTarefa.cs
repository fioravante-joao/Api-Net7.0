using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhasTarefas.Migrations
{
    /// <inheritdoc />
    public partial class AddPropInClassTarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreationUserId",
                table: "Tarefas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Tarefas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationUserId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "Tarefas");
        }
    }
}
