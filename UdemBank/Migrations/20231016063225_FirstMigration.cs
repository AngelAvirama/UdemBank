using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemBank.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    clave = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CuentasDeAhorros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    saldo = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentasDeAhorros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuentasDeAhorros_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GruposDeAhorros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idCreadorGrupo = table.Column<int>(type: "INTEGER", nullable: false),
                    SaldoGrupo = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposDeAhorros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GruposDeAhorros_Usuarios_idCreadorGrupo",
                        column: x => x.idCreadorGrupo,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosXGruposAhorros",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_ParticipanteGrupo = table.Column<int>(type: "INTEGER", nullable: false),
                    id_GrupoAhorro = table.Column<int>(type: "INTEGER", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    PerteneceAlGrupo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosXGruposAhorros", x => x.id);
                    table.ForeignKey(
                        name: "FK_UsuariosXGruposAhorros_GruposDeAhorros_id_GrupoAhorro",
                        column: x => x.id_GrupoAhorro,
                        principalTable: "GruposDeAhorros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosXGruposAhorros_Usuarios_id_ParticipanteGrupo",
                        column: x => x.id_ParticipanteGrupo,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransaccionesGruposAhorros",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idUsuarioXGrupo = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadTransaccion = table.Column<double>(type: "REAL", nullable: false),
                    fecha = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    TipoTransaccion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransaccionesGruposAhorros", x => x.id);
                    table.ForeignKey(
                        name: "FK_TransaccionesGruposAhorros_UsuariosXGruposAhorros_idUsuarioXGrupo",
                        column: x => x.idUsuarioXGrupo,
                        principalTable: "UsuariosXGruposAhorros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuentasDeAhorros_UsuarioId",
                table: "CuentasDeAhorros",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_GruposDeAhorros_idCreadorGrupo",
                table: "GruposDeAhorros",
                column: "idCreadorGrupo");

            migrationBuilder.CreateIndex(
                name: "IX_TransaccionesGruposAhorros_idUsuarioXGrupo",
                table: "TransaccionesGruposAhorros",
                column: "idUsuarioXGrupo");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosXGruposAhorros_id_GrupoAhorro",
                table: "UsuariosXGruposAhorros",
                column: "id_GrupoAhorro");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosXGruposAhorros_id_ParticipanteGrupo",
                table: "UsuariosXGruposAhorros",
                column: "id_ParticipanteGrupo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuentasDeAhorros");

            migrationBuilder.DropTable(
                name: "TransaccionesGruposAhorros");

            migrationBuilder.DropTable(
                name: "UsuariosXGruposAhorros");

            migrationBuilder.DropTable(
                name: "GruposDeAhorros");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
