using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuloCadastro.Migrations
{
    public partial class db_27_05_2025 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SetorEstoqueId",
                table: "tb_produtosvenda",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_produtosvenda_SetorEstoqueId",
                table: "tb_produtosvenda",
                column: "SetorEstoqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_produtosvenda_tb_setorestoque_SetorEstoqueId",
                table: "tb_produtosvenda",
                column: "SetorEstoqueId",
                principalTable: "tb_setorestoque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_produtosvenda_tb_setorestoque_SetorEstoqueId",
                table: "tb_produtosvenda");

            migrationBuilder.DropIndex(
                name: "IX_tb_produtosvenda_SetorEstoqueId",
                table: "tb_produtosvenda");

            migrationBuilder.DropColumn(
                name: "SetorEstoqueId",
                table: "tb_produtosvenda");
        }
    }
}
