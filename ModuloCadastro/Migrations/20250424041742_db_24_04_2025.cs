using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuloCadastro.Migrations
{
    public partial class db_24_04_2025 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_usuario",
                table: "tb_usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_estado",
                table: "tb_estado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_cliente",
                table: "tb_cliente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_cidade",
                table: "tb_cidade");

            migrationBuilder.RenameTable(
                name: "tb_usuario",
                newName: "tb_usuarios");

            migrationBuilder.RenameTable(
                name: "tb_estado",
                newName: "tb_estados");

            migrationBuilder.RenameTable(
                name: "tb_cliente",
                newName: "tb_clientes");

            migrationBuilder.RenameTable(
                name: "tb_cidade",
                newName: "tb_cidades");

            migrationBuilder.AddColumn<int>(
                name: "idBanco",
                table: "tb_autonumerador",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_usuarios",
                table: "tb_usuarios",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_estados",
                table: "tb_estados",
                column: "cuf");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_clientes",
                table: "tb_clientes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_cidades",
                table: "tb_cidades",
                column: "id");

            migrationBuilder.CreateTable(
                name: "tb_bancos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    codigo = table.Column<string>(type: "varchar(5)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    agencia = table.Column<string>(type: "varchar(5)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    agenciaDigito = table.Column<string>(type: "varchar(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    conta = table.Column<string>(type: "varchar(5)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    contaDigito = table.Column<string>(type: "varchar(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tipoConta = table.Column<int>(type: "int", nullable: false),
                    titularNome = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    titularDocumento = table.Column<string>(type: "varchar(14)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pixChave = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pixTipoChave = table.Column<int>(type: "int", nullable: false),
                    contaInternacional = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    inativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    dataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    dataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    iban = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    swiftCode = table.Column<string>(type: "varchar(15)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_bancos", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_bancos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_usuarios",
                table: "tb_usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_estados",
                table: "tb_estados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_clientes",
                table: "tb_clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_cidades",
                table: "tb_cidades");

            migrationBuilder.DropColumn(
                name: "idBanco",
                table: "tb_autonumerador");

            migrationBuilder.RenameTable(
                name: "tb_usuarios",
                newName: "tb_usuario");

            migrationBuilder.RenameTable(
                name: "tb_estados",
                newName: "tb_estado");

            migrationBuilder.RenameTable(
                name: "tb_clientes",
                newName: "tb_cliente");

            migrationBuilder.RenameTable(
                name: "tb_cidades",
                newName: "tb_cidade");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_usuario",
                table: "tb_usuario",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_estado",
                table: "tb_estado",
                column: "cuf");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_cliente",
                table: "tb_cliente",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_cidade",
                table: "tb_cidade",
                column: "id");
        }
    }
}
