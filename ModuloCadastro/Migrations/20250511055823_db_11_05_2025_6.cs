using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuloCadastro.Migrations
{
    public partial class db_11_05_2025_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_tb_clientes_tb_cidades_CidadeId",
                table: "tb_clientes",
                column: "CidadeId",
                principalTable: "tb_cidades",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_clientes_tb_cidades_CidadeId",
                table: "tb_clientes");

            migrationBuilder.RenameColumn(
                name: "CidadeId",
                table: "tb_clientes",
                newName: "End_cidade");

            migrationBuilder.RenameIndex(
                name: "IX_tb_clientes_CidadeId",
                table: "tb_clientes",
                newName: "IX_tb_clientes_End_cidade");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_clientes_tb_cidades_End_cidade",
                table: "tb_clientes",
                column: "End_cidade",
                principalTable: "tb_cidades",
                principalColumn: "Id");
        }
    }
}
