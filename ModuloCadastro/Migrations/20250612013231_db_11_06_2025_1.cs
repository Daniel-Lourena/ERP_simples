using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuloCadastro.Migrations
{
    public partial class db_11_06_2025_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TipoTransferencia",
                table: "tb_recebimento_venda",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdAdquirente",
                table: "tb_autonumerador",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tb_config_adquirente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AdquirenteId = table.Column<int>(type: "int", nullable: false),
                    TaxaDebito = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TaxaCreditoAVista = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TaxaCreditoParcelado = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    NroPacelas = table.Column<int>(type: "int", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    TaxaAntecipacao = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_config_adquirente", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_adquirente_bandeira",
                columns: table => new
                {
                    ConfigAdquirenteId = table.Column<int>(type: "int", nullable: false),
                    BandeiraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_adquirente_bandeira", x => new { x.ConfigAdquirenteId, x.BandeiraId });
                    table.ForeignKey(
                        name: "FK_tb_adquirente_bandeira_tb_config_adquirente_ConfigAdquirente~",
                        column: x => x.ConfigAdquirenteId,
                        principalTable: "tb_config_adquirente",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_maquininhas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AdquirenteId = table.Column<int>(type: "int", nullable: false),
                    TipoMaquininha = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_maquininhas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_maquininhas_tb_config_adquirente_AdquirenteId",
                        column: x => x.AdquirenteId,
                        principalTable: "tb_config_adquirente",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tb_maquininhas_AdquirenteId",
                table: "tb_maquininhas",
                column: "AdquirenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_adquirente_bandeira");

            migrationBuilder.DropTable(
                name: "tb_maquininhas");

            migrationBuilder.DropTable(
                name: "tb_config_adquirente");

            migrationBuilder.DropColumn(
                name: "BandeiraCartao",
                table: "tb_recebimento_venda");

            migrationBuilder.DropColumn(
                name: "MaquininhaId",
                table: "tb_recebimento_venda");

            migrationBuilder.DropColumn(
                name: "IdAdquirente",
                table: "tb_autonumerador");

            migrationBuilder.DropColumn(
                name: "IdMaquininha",
                table: "tb_autonumerador");

            migrationBuilder.AlterColumn<int>(
                name: "TipoTransferencia",
                table: "tb_recebimento_venda",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
