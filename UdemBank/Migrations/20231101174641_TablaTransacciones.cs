using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemBank.Migrations
{
    /// <inheritdoc />
    public partial class TablaTransacciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransaccionesCuentaAhorros",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_cuentaDeAhorro = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadTransaccion = table.Column<double>(type: "REAL", nullable: false),
                    fecha = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    TipoTransaccion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransaccionesCuentaAhorros", x => x.id);
                    table.ForeignKey(
                        name: "FK_TransaccionesCuentaAhorros_CuentasDeAhorros_id_cuentaDeAhorro",
                        column: x => x.id_cuentaDeAhorro,
                        principalTable: "CuentasDeAhorros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransaccionesCuentaAhorros_id_cuentaDeAhorro",
                table: "TransaccionesCuentaAhorros",
                column: "id_cuentaDeAhorro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransaccionesCuentaAhorros");
        }
    }
}
