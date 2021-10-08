using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class AjustandoOutrasTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ctps",
                table: "Professores",
                newName: "Licenca");

            migrationBuilder.RenameColumn(
                name: "Ctps",
                table: "Colaboradores",
                newName: "Formacao");

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Responsavel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Responsavel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CPTS",
                table: "Professores",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Formacao",
                table: "Professores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CPTS",
                table: "Colaboradores",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Responsavel");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Responsavel");

            migrationBuilder.DropColumn(
                name: "CPTS",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "Formacao",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "CPTS",
                table: "Colaboradores");

            migrationBuilder.RenameColumn(
                name: "Licenca",
                table: "Professores",
                newName: "Ctps");

            migrationBuilder.RenameColumn(
                name: "Formacao",
                table: "Colaboradores",
                newName: "Ctps");
        }
    }
}
