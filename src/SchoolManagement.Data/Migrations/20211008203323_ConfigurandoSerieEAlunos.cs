using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class ConfigurandoSerieEAlunos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QtdAlunos",
                table: "Turmas");

            migrationBuilder.AddColumn<long>(
                name: "EnderecoId",
                table: "Professores",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "EnderecoId",
                table: "Colaboradores",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "EnderecoId",
                table: "Alunos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Professores_EnderecoId",
                table: "Professores",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_EnderecoId",
                table: "Colaboradores",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_EnderecoId",
                table: "Alunos",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Enderecos_EnderecoId",
                table: "Alunos",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradores_Enderecos_EnderecoId",
                table: "Colaboradores",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Enderecos_EnderecoId",
                table: "Professores",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Enderecos_EnderecoId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_Enderecos_EnderecoId",
                table: "Colaboradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Enderecos_EnderecoId",
                table: "Professores");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Professores_EnderecoId",
                table: "Professores");

            migrationBuilder.DropIndex(
                name: "IX_Colaboradores_EnderecoId",
                table: "Colaboradores");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_EnderecoId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Alunos");

            migrationBuilder.AddColumn<string>(
                name: "QtdAlunos",
                table: "Turmas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
