using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuloCadastro.Migrations
{
    public partial class db_01_05_2025 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PedidoVendaEntityid",
                table: "tb_produtosvenda");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataFechamento",
                table: "tb_vendas",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataExclusao",
                table: "tb_vendas",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataCriacao",
                table: "tb_vendas",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataAtualizacao",
                table: "tb_vendas",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "tb_vendas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<decimal>(
                name: "quantidade",
                table: "tb_produtosvenda",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AddColumn<int>(
                name: "DadosProdutoid",
                table: "tb_produtosvenda",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "valor",
                table: "tb_produtosvenda",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_tb_produtosvenda_DadosProdutoid",
                table: "tb_produtosvenda",
                column: "DadosProdutoid");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_cidades_tb_estados_cuf",
                table: "tb_cidades",
                column: "cuf",
                principalTable: "tb_estados",
                principalColumn: "cuf");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_clientes_tb_cidades_end_cidade",
                table: "tb_clientes",
                column: "end_cidade",
                principalTable: "tb_cidades",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_estoque_tb_produtos_idProduto",
                table: "tb_estoque",
                column: "idProduto",
                principalTable: "tb_produtos",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_estoque_tb_setorestoque_setorEstoque",
                table: "tb_estoque",
                column: "setorEstoque",
                principalTable: "tb_setorestoque",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_produtos_tb_categoria_categoria",
                table: "tb_produtos",
                column: "categoria",
                principalTable: "tb_categoria",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_produtosvenda_tb_produtos_DadosProdutoid",
                table: "tb_produtosvenda",
                column: "DadosProdutoid",
                principalTable: "tb_produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_produtosvenda_tb_vendas_idPedido",
                table: "tb_produtosvenda",
                column: "idPedido",
                principalTable: "tb_vendas",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_vendas_tb_clientes_idCliente",
                table: "tb_vendas",
                column: "idCliente",
                principalTable: "tb_clientes",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_cidades_tb_estados_cuf",
                table: "tb_cidades");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_clientes_tb_cidades_end_cidade",
                table: "tb_clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_estoque_tb_produtos_idProduto",
                table: "tb_estoque");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_estoque_tb_setorestoque_setorEstoque",
                table: "tb_estoque");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_produtos_tb_categoria_categoria",
                table: "tb_produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_produtosvenda_tb_produtos_DadosProdutoid",
                table: "tb_produtosvenda");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_produtosvenda_tb_vendas_idPedido",
                table: "tb_produtosvenda");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_vendas_tb_clientes_idCliente",
                table: "tb_vendas");

            migrationBuilder.DropIndex(
                name: "IX_tb_produtosvenda_DadosProdutoid",
                table: "tb_produtosvenda");

            migrationBuilder.DropColumn(
                name: "DadosProdutoid",
                table: "tb_produtosvenda");

            migrationBuilder.DropColumn(
                name: "valor",
                table: "tb_produtosvenda");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataFechamento",
                table: "tb_vendas",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataExclusao",
                table: "tb_vendas",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataCriacao",
                table: "tb_vendas",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataAtualizacao",
                table: "tb_vendas",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "tb_vendas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<decimal>(
                name: "quantidade",
                table: "tb_produtosvenda",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AddColumn<int>(
                name: "PedidoVendaEntityid",
                table: "tb_produtosvenda",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_produtosvenda_idProduto",
                table: "tb_produtosvenda",
                column: "idProduto");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produtosvenda_PedidoVendaEntityid",
                table: "tb_produtosvenda",
                column: "PedidoVendaEntityid");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_cidades_tb_estados_cuf",
                table: "tb_cidades",
                column: "cuf",
                principalTable: "tb_estados",
                principalColumn: "cuf",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_clientes_tb_cidades_end_cidade",
                table: "tb_clientes",
                column: "end_cidade",
                principalTable: "tb_cidades",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_estoque_tb_produtos_idProduto",
                table: "tb_estoque",
                column: "idProduto",
                principalTable: "tb_produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_estoque_tb_setorestoque_setorEstoque",
                table: "tb_estoque",
                column: "setorEstoque",
                principalTable: "tb_setorestoque",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_produtos_tb_categoria_categoria",
                table: "tb_produtos",
                column: "categoria",
                principalTable: "tb_categoria",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_produtosvenda_tb_produtos_idProduto",
                table: "tb_produtosvenda",
                column: "idProduto",
                principalTable: "tb_produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_produtosvenda_tb_vendas_idPedido",
                table: "tb_produtosvenda",
                column: "idPedido",
                principalTable: "tb_vendas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_produtosvenda_tb_vendas_PedidoVendaEntityid",
                table: "tb_produtosvenda",
                column: "PedidoVendaEntityid",
                principalTable: "tb_vendas",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_vendas_tb_clientes_idCliente",
                table: "tb_vendas",
                column: "idCliente",
                principalTable: "tb_clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
