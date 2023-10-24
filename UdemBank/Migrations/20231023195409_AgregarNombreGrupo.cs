using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemBank.Migrations
{
    /// <inheritdoc />
    public partial class AgregarNombreGrupo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "UsuariosXGruposAhorros");

            migrationBuilder.AddColumn<string>(
                name: "NombreGrupo",
                table: "GruposDeAhorros",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreGrupo",
                table: "GruposDeAhorros");

            migrationBuilder.AddColumn<DateOnly>(
                name: "ReleaseDate",
                table: "UsuariosXGruposAhorros",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
