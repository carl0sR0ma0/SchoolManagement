using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class ReconfigurandoTabelaAluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Bairro",
                table: "Professores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Professores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Professores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Professores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Professores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Colaboradores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Colaboradores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Colaboradores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Colaboradores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Colaboradores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Alunos");

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
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}
