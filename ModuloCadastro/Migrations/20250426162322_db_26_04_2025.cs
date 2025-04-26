using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuloCadastro.Migrations
{
    public partial class db_26_04_2025 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idPedido",
                table: "tb_autonumerador",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tb_pedidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    idCriador = table.Column<int>(type: "int", nullable: false),
                    dataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    dataAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    usuarioAtualizacao = table.Column<int>(type: "int", nullable: false),
                    excluido = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    dataExclusao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pedidos", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_pedidos_tb_clientes_idCliente",
                        column: x => x.idCliente,
                        principalTable: "tb_clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_produtospedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idPedido = table.Column<int>(type: "int", nullable: false),
                    idProduto = table.Column<int>(type: "int", nullable: false),
                    DadosProdutoid = table.Column<int>(type: "int", nullable: false),
                    PedidoEntityid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_produtospedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_produtospedido_tb_pedidos_PedidoEntityid",
                        column: x => x.PedidoEntityid,
                        principalTable: "tb_pedidos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_produtospedido_tb_produtos_DadosProdutoid",
                        column: x => x.DadosProdutoid,
                        principalTable: "tb_produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produtos_categoria",
                table: "tb_produtos",
                column: "categoria");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produtos_setorEstoque",
                table: "tb_produtos",
                column: "setorEstoque");

            migrationBuilder.CreateIndex(
                name: "IX_tb_clientes_end_cidade",
                table: "tb_clientes",
                column: "end_cidade");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cidades_cuf",
                table: "tb_cidades",
                column: "cuf");

            migrationBuilder.CreateIndex(
                name: "IX_tb_pedidos_idCliente",
                table: "tb_pedidos",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produtospedido_DadosProdutoid",
                table: "tb_produtospedido",
                column: "DadosProdutoid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produtospedido_PedidoEntityid",
                table: "tb_produtospedido",
                column: "PedidoEntityid");

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
                name: "FK_tb_produtos_tb_categoria_categoria",
                table: "tb_produtos",
                column: "categoria",
                principalTable: "tb_categoria",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_produtos_tb_setorestoque_setorEstoque",
                table: "tb_produtos",
                column: "setorEstoque",
                principalTable: "tb_setorestoque",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
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
                name: "FK_tb_produtos_tb_categoria_categoria",
                table: "tb_produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_produtos_tb_setorestoque_setorEstoque",
                table: "tb_produtos");

            migrationBuilder.DropTable(
                name: "tb_produtospedido");

            migrationBuilder.DropTable(
                name: "tb_pedidos");

            migrationBuilder.DropIndex(
                name: "IX_tb_produtos_categoria",
                table: "tb_produtos");

            migrationBuilder.DropIndex(
                name: "IX_tb_produtos_setorEstoque",
                table: "tb_produtos");

            migrationBuilder.DropIndex(
                name: "IX_tb_clientes_end_cidade",
                table: "tb_clientes");

            migrationBuilder.DropIndex(
                name: "IX_tb_cidades_cuf",
                table: "tb_cidades");

            migrationBuilder.DropColumn(
                name: "idPedido",
                table: "tb_autonumerador");
        }
    }
}
