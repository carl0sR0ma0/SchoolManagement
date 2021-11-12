using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class CorrigindoTabelaNotas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisciplinasMatriculadas_Disciplinas_DisciplinaId",
                table: "DisciplinasMatriculadas");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplinasMatriculadas_Professores_ProfessorId",
                table: "DisciplinasMatriculadas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DisciplinasMatriculadas",
                table: "DisciplinasMatriculadas");

            migrationBuilder.RenameTable(
                name: "DisciplinasMatriculadas",
                newName: "Disciplinas Matriculadas");

            migrationBuilder.RenameIndex(
                name: "IX_DisciplinasMatriculadas_ProfessorId",
                table: "Disciplinas Matriculadas",
                newName: "IX_Disciplinas Matriculadas_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_DisciplinasMatriculadas_DisciplinaId",
                table: "Disciplinas Matriculadas",
                newName: "IX_Disciplinas Matriculadas_DisciplinaId");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Disciplinas Matriculadas",
                type: "BIGINT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Disciplinas Matriculadas_Id",
                table: "Disciplinas Matriculadas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disciplinas Matriculadas",
                table: "Disciplinas Matriculadas",
                columns: new[] { "Id", "ProfessorId", "DisciplinaId" });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    AlunoId = table.Column<long>(type: "BIGINT", nullable: false),
                    DisciplinaId = table.Column<long>(type: "BIGINT", nullable: false),
                    Nota1 = table.Column<double>(type: "float", nullable: false),
                    Nota2 = table.Column<double>(type: "float", nullable: false),
                    Nota3 = table.Column<double>(type: "float", nullable: false),
                    Nota4 = table.Column<double>(type: "float", nullable: false),
                    Media = table.Column<double>(type: "float", nullable: false),
                    AprovadoReprovado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_Notas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notas_Disciplinas Matriculadas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas Matriculadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notas_DisciplinaId",
                table: "Notas",
                column: "DisciplinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas Matriculadas_Disciplinas_DisciplinaId",
                table: "Disciplinas Matriculadas",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas Matriculadas_Professores_ProfessorId",
                table: "Disciplinas Matriculadas",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas Matriculadas_Disciplinas_DisciplinaId",
                table: "Disciplinas Matriculadas");

            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas Matriculadas_Professores_ProfessorId",
                table: "Disciplinas Matriculadas");

            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Disciplinas Matriculadas_Id",
                table: "Disciplinas Matriculadas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disciplinas Matriculadas",
                table: "Disciplinas Matriculadas");

            migrationBuilder.RenameTable(
                name: "Disciplinas Matriculadas",
                newName: "DisciplinasMatriculadas");

            migrationBuilder.RenameIndex(
                name: "IX_Disciplinas Matriculadas_ProfessorId",
                table: "DisciplinasMatriculadas",
                newName: "IX_DisciplinasMatriculadas_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_Disciplinas Matriculadas_DisciplinaId",
                table: "DisciplinasMatriculadas",
                newName: "IX_DisciplinasMatriculadas_DisciplinaId");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "DisciplinasMatriculadas",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "BIGINT")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DisciplinasMatriculadas",
                table: "DisciplinasMatriculadas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinasMatriculadas_Disciplinas_DisciplinaId",
                table: "DisciplinasMatriculadas",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinasMatriculadas_Professores_ProfessorId",
                table: "DisciplinasMatriculadas",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
