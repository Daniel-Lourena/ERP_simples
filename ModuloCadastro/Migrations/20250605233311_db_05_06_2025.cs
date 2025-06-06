using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuloCadastro.Migrations
{
    public partial class db_05_06_2025 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Agencia",
                table: "tb_recebimento_venda",
                type: "varchar(10)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "BancoId",
                table: "tb_recebimento_venda",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaCorrente",
                table: "tb_recebimento_venda",
                type: "varchar(100)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DigitoAgencia",
                table: "tb_recebimento_venda",
                type: "varchar(1)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DigitoContaCorrente",
                table: "tb_recebimento_venda",
                type: "varchar(1)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NomeEmissor",
                table: "tb_recebimento_venda",
                type: "varchar(100)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NroDocumento",
                table: "tb_recebimento_venda",
                type: "varchar(100)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agencia",
                table: "tb_recebimento_venda");

            migrationBuilder.DropColumn(
                name: "BancoId",
                table: "tb_recebimento_venda");

            migrationBuilder.DropColumn(
                name: "ContaCorrente",
                table: "tb_recebimento_venda");

            migrationBuilder.DropColumn(
                name: "DigitoAgencia",
                table: "tb_recebimento_venda");

            migrationBuilder.DropColumn(
                name: "DigitoContaCorrente",
                table: "tb_recebimento_venda");

            migrationBuilder.DropColumn(
                name: "NomeEmissor",
                table: "tb_recebimento_venda");

            migrationBuilder.DropColumn(
                name: "NroDocumento",
                table: "tb_recebimento_venda");
        }
    }
}
