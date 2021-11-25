using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class CorrigindoNomeColuna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisciplinaMatriculada_Disciplinas_DisicplinaId",
                table: "DisciplinaMatriculada");

            migrationBuilder.RenameColumn(
                name: "DisicplinaId",
                table: "DisciplinaMatriculada",
                newName: "DisciplinaId");

            migrationBuilder.RenameIndex(
                name: "IX_DisciplinaMatriculada_DisicplinaId",
                table: "DisciplinaMatriculada",
                newName: "IX_DisciplinaMatriculada_DisciplinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinaMatriculada_Disciplinas_DisciplinaId",
                table: "DisciplinaMatriculada",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisciplinaMatriculada_Disciplinas_DisciplinaId",
                table: "DisciplinaMatriculada");

            migrationBuilder.RenameColumn(
                name: "DisciplinaId",
                table: "DisciplinaMatriculada",
                newName: "DisicplinaId");

            migrationBuilder.RenameIndex(
                name: "IX_DisciplinaMatriculada_DisciplinaId",
                table: "DisciplinaMatriculada",
                newName: "IX_DisciplinaMatriculada_DisicplinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinaMatriculada_Disciplinas_DisicplinaId",
                table: "DisciplinaMatriculada",
                column: "DisicplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
