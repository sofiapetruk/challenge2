using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace challenge2.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoMotos",
                columns: table => new
                {
                    IdTipo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NmTipo = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMotos", x => x.IdTipo);
                });

            migrationBuilder.CreateTable(
                name: "TipoStatus",
                columns: table => new
                {
                    IdStatus = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Status = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoStatus", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Motos",
                columns: table => new
                {
                    IdMoto = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NmChassi = table.Column<string>(type: "NVARCHAR2(17)", maxLength: 17, nullable: false),
                    Placa = table.Column<string>(type: "NVARCHAR2(7)", maxLength: 7, nullable: false),
                    Unidade = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    StatusMotoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdTipoMoto = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motos", x => x.IdMoto);
                    table.ForeignKey(
                        name: "FK_Moto_Status",
                        column: x => x.StatusMotoId,
                        principalTable: "TipoStatus",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Moto_Tipo",
                        column: x => x.IdTipoMoto,
                        principalTable: "TipoMotos",
                        principalColumn: "IdTipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motos_IdTipoMoto",
                table: "Motos",
                column: "IdTipoMoto");

            migrationBuilder.CreateIndex(
                name: "IX_Motos_StatusMotoId",
                table: "Motos",
                column: "StatusMotoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TipoStatus");

            migrationBuilder.DropTable(
                name: "TipoMotos");
        }
    }
}
