using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuloCadastro.Migrations
{
    public partial class db_11_05_2025_criacao_banco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_autonumerador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdProduto = table.Column<int>(type: "int", nullable: false),
                    IdBanco = table.Column<int>(type: "int", nullable: false),
                    IdPedidoVenda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_autonumerador", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_bancos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Codigo = table.Column<string>(type: "varchar(5)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Agencia = table.Column<string>(type: "varchar(5)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AgenciaDigito = table.Column<string>(type: "varchar(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Conta = table.Column<string>(type: "varchar(5)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContaDigito = table.Column<string>(type: "varchar(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoConta = table.Column<int>(type: "int", nullable: false),
                    TitularNome = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TitularDocumento = table.Column<string>(type: "varchar(14)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PixChave = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PixTipoChave = table.Column<int>(type: "int", nullable: false),
                    ContaInternacional = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Inativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Iban = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SwiftCode = table.Column<string>(type: "varchar(15)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_bancos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_categoria", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_estados",
                columns: table => new
                {
                    Cuf = table.Column<int>(type: "int", nullable: false),
                    Uf = table.Column<string>(type: "varchar(2)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_estados", x => x.Cuf);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_setorestoque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_setorestoque", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cargo = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Excluido = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(150)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UnidadeId = table.Column<int>(type: "int", nullable: false),
                    Cest = table.Column<string>(type: "varchar(7)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ncm = table.Column<string>(type: "varchar(8)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoEstoque_SKU = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    EstoqueMinimo = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Origem = table.Column<int>(type: "int", nullable: false),
                    Cst_csosn = table.Column<string>(type: "varchar(5)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UsuarioCadastroId = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_produtos_tb_categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "tb_categoria",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_cidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Cuf = table.Column<int>(type: "int", nullable: false),
                    Cmunicipio = table.Column<string>(type: "varchar(10)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dmunicipio = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_cidades_tb_estados_Cuf",
                        column: x => x.Cuf,
                        principalTable: "tb_estados",
                        principalColumn: "Cuf");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_estoque",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    SetorEstoqueId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_estoque", x => new { x.ProdutoId, x.SetorEstoqueId });
                    table.ForeignKey(
                        name: "FK_tb_estoque_tb_produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "tb_produtos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_estoque_tb_setorestoque_SetorEstoqueId",
                        column: x => x.SetorEstoqueId,
                        principalTable: "tb_setorestoque",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fantasia = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LimiteCredito = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    End_nomeRua = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    End_bairro = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    End_numero = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    End_logradouro = table.Column<string>(type: "varchar(10)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    End_uf = table.Column<int>(type: "int", nullable: false),
                    End_cidade = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Excluido = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_clientes_tb_cidades_End_cidade",
                        column: x => x.End_cidade,
                        principalTable: "tb_cidades",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_vendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<int>(type: "int", nullable: false),
                    Excluido = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioFechamentoId = table.Column<int>(type: "int", nullable: true),
                    DataFechamento = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_vendas_tb_clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "tb_clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_vendas_tb_usuarios_UsuarioAtualizacaoId",
                        column: x => x.UsuarioAtualizacaoId,
                        principalTable: "tb_usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_vendas_tb_usuarios_UsuarioCriacaoId",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "tb_usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_vendas_tb_usuarios_UsuarioFechamentoId",
                        column: x => x.UsuarioFechamentoId,
                        principalTable: "tb_usuarios",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_produtosvenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PedidoVendaId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_produtosvenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_produtosvenda_tb_produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "tb_produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_produtosvenda_tb_vendas_PedidoVendaId",
                        column: x => x.PedidoVendaId,
                        principalTable: "tb_vendas",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cidades_Cuf",
                table: "tb_cidades",
                column: "Cuf");

            migrationBuilder.CreateIndex(
                name: "IX_tb_clientes_End_cidade",
                table: "tb_clientes",
                column: "End_cidade");

            migrationBuilder.CreateIndex(
                name: "IX_tb_estoque_SetorEstoqueId",
                table: "tb_estoque",
                column: "SetorEstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produtos_CategoriaId",
                table: "tb_produtos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produtosvenda_PedidoVendaId",
                table: "tb_produtosvenda",
                column: "PedidoVendaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produtosvenda_ProdutoId",
                table: "tb_produtosvenda",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_vendas_ClienteId",
                table: "tb_vendas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_vendas_UsuarioAtualizacaoId",
                table: "tb_vendas",
                column: "UsuarioAtualizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_vendas_UsuarioCriacaoId",
                table: "tb_vendas",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_vendas_UsuarioFechamentoId",
                table: "tb_vendas",
                column: "UsuarioFechamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_autonumerador");

            migrationBuilder.DropTable(
                name: "tb_bancos");

            migrationBuilder.DropTable(
                name: "tb_estoque");

            migrationBuilder.DropTable(
                name: "tb_produtosvenda");

            migrationBuilder.DropTable(
                name: "tb_setorestoque");

            migrationBuilder.DropTable(
                name: "tb_produtos");

            migrationBuilder.DropTable(
                name: "tb_vendas");

            migrationBuilder.DropTable(
                name: "tb_categoria");

            migrationBuilder.DropTable(
                name: "tb_clientes");

            migrationBuilder.DropTable(
                name: "tb_usuarios");

            migrationBuilder.DropTable(
                name: "tb_cidades");

            migrationBuilder.DropTable(
                name: "tb_estados");
        }
    }
}
