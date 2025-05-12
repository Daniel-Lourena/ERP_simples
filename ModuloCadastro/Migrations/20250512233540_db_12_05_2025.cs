using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuloCadastro.Migrations
{
    public partial class db_12_05_2025 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioExclusaoId",
                table: "tb_vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_vendas_UsuarioExclusaoId",
                table: "tb_vendas",
                column: "UsuarioExclusaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_vendas_tb_usuarios_UsuarioExclusaoId",
                table: "tb_vendas",
                column: "UsuarioExclusaoId",
                principalTable: "tb_usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_vendas_tb_usuarios_UsuarioExclusaoId",
                table: "tb_vendas");

            migrationBuilder.DropIndex(
                name: "IX_tb_vendas_UsuarioExclusaoId",
                table: "tb_vendas");

            migrationBuilder.DropColumn(
                name: "UsuarioExclusaoId",
                table: "tb_vendas");
        }
    }
}
