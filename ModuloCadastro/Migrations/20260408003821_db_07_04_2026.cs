using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuloCadastro.Migrations
{
    /// <inheritdoc />
    public partial class db_07_04_2026 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Departamento",
                table: "tb_usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "tb_usuarios",
                type: "varchar(100)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "PerfilAcesso",
                table: "tb_usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "tb_usuarios",
                type: "varchar(100)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_usuario_permissao",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    PermissaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuario_permissao", x => new { x.UsuarioId, x.PermissaoId });
                    table.ForeignKey(
                        name: "FK_tb_usuario_permissao_tb_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tb_usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_usuario_permissao");

            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "tb_usuarios");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "tb_usuarios");

            migrationBuilder.DropColumn(
                name: "PerfilAcesso",
                table: "tb_usuarios");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "tb_usuarios");
        }
    }
}
