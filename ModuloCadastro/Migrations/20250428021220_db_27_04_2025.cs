using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuloCadastro.Migrations
{
    public partial class db_27_04_2025 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_produtos_tb_setorestoque_setorEstoque",
                table: "tb_produtos");

            migrationBuilder.DropTable(
                name: "tb_produtospedido");

            migrationBuilder.DropTable(
                name: "tb_pedidos");

            migrationBuilder.DropIndex(
                name: "IX_tb_produtos_setorEstoque",
                table: "tb_produtos");

            migrationBuilder.DropColumn(
                name: "setorEstoque",
                table: "tb_produtos");

            migrationBuilder.RenameColumn(
                name: "idPedido",
                table: "tb_autonumerador",
                newName: "idPedidoVenda");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataExclusao",
                table: "tb_usuarios",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<int>(
                name: "idUnidade",
                table: "tb_produtos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_estoque",
                columns: table => new
                {
                    idProduto = table.Column<int>(type: "int", nullable: false),
                    setorEstoque = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_estoque", x => new { x.idProduto, x.setorEstoque });
                    table.ForeignKey(
                        name: "FK_tb_estoque_tb_produtos_idProduto",
                        column: x => x.idProduto,
                        principalTable: "tb_produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_estoque_tb_setorestoque_setorEstoque",
                        column: x => x.setorEstoque,
                        principalTable: "tb_setorestoque",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_vendas",
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
                    dataExclusao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    usuarioFechamento = table.Column<int>(type: "int", nullable: false),
                    dataFechamento = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_vendas", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_vendas_tb_clientes_idCliente",
                        column: x => x.idCliente,
                        principalTable: "tb_clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_produtosvenda",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idPedido = table.Column<int>(type: "int", nullable: false),
                    idProduto = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PedidoVendaEntityid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_produtosvenda", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_produtosvenda_tb_produtos_idProduto",
                        column: x => x.idProduto,
                        principalTable: "tb_produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_produtosvenda_tb_vendas_idPedido",
                        column: x => x.idPedido,
                        principalTable: "tb_vendas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_produtosvenda_tb_vendas_PedidoVendaEntityid",
                        column: x => x.PedidoVendaEntityid,
                        principalTable: "tb_vendas",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tb_estoque_setorEstoque",
                table: "tb_estoque",
                column: "setorEstoque");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produtosvenda_idPedido",
                table: "tb_produtosvenda",
                column: "idPedido");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produtosvenda_idProduto",
                table: "tb_produtosvenda",
                column: "idProduto");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produtosvenda_PedidoVendaEntityid",
                table: "tb_produtosvenda",
                column: "PedidoVendaEntityid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_vendas_idCliente",
                table: "tb_vendas",
                column: "idCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_estoque");

            migrationBuilder.DropTable(
                name: "tb_produtosvenda");

            migrationBuilder.DropTable(
                name: "tb_vendas");

            migrationBuilder.RenameColumn(
                name: "idPedidoVenda",
                table: "tb_autonumerador",
                newName: "idPedido");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataExclusao",
                table: "tb_usuarios",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "idUnidade",
                table: "tb_produtos",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "setorEstoque",
                table: "tb_produtos",
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
                    dataAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    dataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    dataExclusao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    excluido = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    idCriador = table.Column<int>(type: "int", nullable: false),
                    usuarioAtualizacao = table.Column<int>(type: "int", nullable: false)
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
                    DadosProdutoid = table.Column<int>(type: "int", nullable: false),
                    PedidoEntityid = table.Column<int>(type: "int", nullable: true),
                    idPedido = table.Column<int>(type: "int", nullable: false),
                    idProduto = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_tb_produtos_setorEstoque",
                table: "tb_produtos",
                column: "setorEstoque");

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
                name: "FK_tb_produtos_tb_setorestoque_setorEstoque",
                table: "tb_produtos",
                column: "setorEstoque",
                principalTable: "tb_setorestoque",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
