using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ophelia.Infrastructure.Persistence.Migrations
{
    public partial class ExistenciasMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "existencias",
                schema: "facturacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    ArticuloId = table.Column<int>(nullable: false),
                    ExistenciaMinima = table.Column<decimal>(type: "numeric(28, 8)", nullable: false),
                    ExistenciaMaxima = table.Column<decimal>(type: "numeric(28, 8)", nullable: false),
                    CantDisponible = table.Column<decimal>(type: "numeric(28, 8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_existencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_existencias_articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalSchema: "facturacion",
                        principalTable: "articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_existencias_ArticuloId",
                schema: "facturacion",
                table: "existencias",
                column: "ArticuloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "existencias",
                schema: "facturacion");
        }
    }
}
