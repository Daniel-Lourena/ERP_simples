using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuloCadastro.Migrations
{
    public partial class db_05_06_2025_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataEmissaoDocumento",
                table: "tb_recebimento_venda",
                type: "datetime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataEmissaoDocumento",
                table: "tb_recebimento_venda");
        }
    }
}
