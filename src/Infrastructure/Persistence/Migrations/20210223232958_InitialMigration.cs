using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ophelia.Infrastructure.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "facturacion");

            migrationBuilder.CreateTable(
                name: "tipodocumentos",
                schema: "facturacion",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Detalle = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipodocumentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "unidades",
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
                    Detalle = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
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
                    TipoDocumentoId = table.Column<string>(nullable: true),
                    NroDocumento = table.Column<string>(type: "varchar(20)", nullable: false),
                    PrimerNombre = table.Column<string>(type: "varchar(40)", nullable: false),
                    SegundoNombre = table.Column<string>(type: "varchar(40)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clientes_tipodocumentos_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalSchema: "facturacion",
                        principalTable: "tipodocumentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "articulos",
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
                    Detalle = table.Column<string>(type: "varchar(50)", nullable: false),
                    UnidadId = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(type: "numeric(28, 8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_articulos_unidades_UnidadId",
                        column: x => x.UnidadId,
                        principalSchema: "facturacion",
                        principalTable: "unidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ventas",
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
                    FechaVenta = table.Column<DateTime>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    VlrVenta = table.Column<decimal>(type: "numeric(28, 8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ventas_clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalSchema: "facturacion",
                        principalTable: "clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "detalleventas",
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
                    VentaId = table.Column<int>(nullable: false),
                    ArticuloId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<decimal>(type: "numeric(28, 8)", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric(28, 8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalleventas_articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalSchema: "facturacion",
                        principalTable: "articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_detalleventas_ventas_VentaId",
                        column: x => x.VentaId,
                        principalSchema: "facturacion",
                        principalTable: "ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_articulos_UnidadId",
                schema: "facturacion",
                table: "articulos",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_clientes_TipoDocumentoId",
                schema: "facturacion",
                table: "clientes",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleventas_ArticuloId",
                schema: "facturacion",
                table: "detalleventas",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleventas_VentaId",
                schema: "facturacion",
                table: "detalleventas",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_ClienteId",
                schema: "facturacion",
                table: "ventas",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalleventas",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "articulos",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "ventas",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "unidades",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "clientes",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "tipodocumentos",
                schema: "facturacion");
        }
    }
}
