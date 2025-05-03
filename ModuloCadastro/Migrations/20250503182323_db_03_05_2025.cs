using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuloCadastro.Migrations
{
    public partial class db_03_05_2025 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tb_vendas_idCriador",
                table: "tb_vendas",
                column: "idCriador");

            migrationBuilder.CreateIndex(
                name: "IX_tb_vendas_usuarioAtualizacao",
                table: "tb_vendas",
                column: "usuarioAtualizacao");

            migrationBuilder.CreateIndex(
                name: "IX_tb_vendas_usuarioFechamento",
                table: "tb_vendas",
                column: "usuarioFechamento");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_vendas_tb_usuarios_idCriador",
                table: "tb_vendas",
                column: "idCriador",
                principalTable: "tb_usuarios",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_vendas_tb_usuarios_usuarioAtualizacao",
                table: "tb_vendas",
                column: "usuarioAtualizacao",
                principalTable: "tb_usuarios",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_vendas_tb_usuarios_usuarioFechamento",
                table: "tb_vendas",
                column: "usuarioFechamento",
                principalTable: "tb_usuarios",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_vendas_tb_usuarios_idCriador",
                table: "tb_vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_vendas_tb_usuarios_usuarioAtualizacao",
                table: "tb_vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_vendas_tb_usuarios_usuarioFechamento",
                table: "tb_vendas");

            migrationBuilder.DropIndex(
                name: "IX_tb_vendas_idCriador",
                table: "tb_vendas");

            migrationBuilder.DropIndex(
                name: "IX_tb_vendas_usuarioAtualizacao",
                table: "tb_vendas");

            migrationBuilder.DropIndex(
                name: "IX_tb_vendas_usuarioFechamento",
                table: "tb_vendas");
        }
    }
}
