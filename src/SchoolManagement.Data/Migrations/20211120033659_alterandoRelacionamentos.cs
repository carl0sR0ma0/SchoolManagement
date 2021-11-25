using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class alterandoRelacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisciplinaMatriculada_DisciplinaProfessor_DisicplinaProfessorId",
                table: "DisciplinaMatriculada");

            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Alunos_AlunoId",
                table: "Matriculas");

            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Turmas_TurmaId",
                table: "Matriculas");

            migrationBuilder.DropForeignKey(
                name: "FK_Notas_DisciplinaMatriculada_DisciplinaMatriculadaId",
                table: "Notas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notas",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Matriculas_AlunoId",
                table: "Matriculas");

            migrationBuilder.DropIndex(
                name: "IX_Matriculas_TurmaId",
                table: "Matriculas");

            migrationBuilder.RenameColumn(
                name: "DisciplinaMatriculadaId",
                table: "Notas",
                newName: "DisciplinaId");

            migrationBuilder.RenameIndex(
                name: "IX_Notas_DisciplinaMatriculadaId",
                table: "Notas",
                newName: "IX_Notas_DisciplinaId");

            migrationBuilder.RenameColumn(
                name: "DisicplinaProfessorId",
                table: "DisciplinaMatriculada",
                newName: "DisicplinaId");

            migrationBuilder.RenameIndex(
                name: "IX_DisciplinaMatriculada_DisicplinaProfessorId",
                table: "DisciplinaMatriculada",
                newName: "IX_DisciplinaMatriculada_DisicplinaId");

            migrationBuilder.AlterColumn<double>(
                name: "Nota4",
                table: "Notas",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Nota3",
                table: "Notas",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Nota2",
                table: "Notas",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Nota1",
                table: "Notas",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Media",
                table: "Notas",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<bool>(
                name: "AprovadoReprovado",
                table: "Notas",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<long>(
                name: "TurmaId",
                table: "Notas",
                type: "BIGINT",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notas",
                table: "Notas",
                columns: new[] { "AlunoId", "TurmaId", "DisciplinaId" });

            migrationBuilder.CreateTable(
                name: "PlanoDeEnsino",
                columns: table => new
                {
                    TurmaId = table.Column<long>(type: "BIGINT", nullable: false),
                    DisciplinaId = table.Column<long>(type: "BIGINT", nullable: false),
                    Dia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Horario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtdAulas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoDeEnsino", x => new { x.TurmaId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_PlanoDeEnsino_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanoDeEnsino_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notas_TurmaId",
                table: "Notas",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_AlunoId",
                table: "Matriculas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_TurmaId",
                table: "Matriculas",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoDeEnsino_DisciplinaId",
                table: "PlanoDeEnsino",
                column: "DisciplinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinaMatriculada_Disciplinas_DisicplinaId",
                table: "DisciplinaMatriculada",
                column: "DisicplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Alunos_AlunoId",
                table: "Matriculas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Turmas_TurmaId",
                table: "Matriculas",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Disciplinas_DisciplinaId",
                table: "Notas",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Turmas_TurmaId",
                table: "Notas",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisciplinaMatriculada_Disciplinas_DisicplinaId",
                table: "DisciplinaMatriculada");

            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Alunos_AlunoId",
                table: "Matriculas");

            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Turmas_TurmaId",
                table: "Matriculas");

            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Disciplinas_DisciplinaId",
                table: "Notas");

            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Turmas_TurmaId",
                table: "Notas");

            migrationBuilder.DropTable(
                name: "PlanoDeEnsino");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notas",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_TurmaId",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Matriculas_AlunoId",
                table: "Matriculas");

            migrationBuilder.DropIndex(
                name: "IX_Matriculas_TurmaId",
                table: "Matriculas");

            migrationBuilder.DropColumn(
                name: "TurmaId",
                table: "Notas");

            migrationBuilder.RenameColumn(
                name: "DisciplinaId",
                table: "Notas",
                newName: "DisciplinaMatriculadaId");

            migrationBuilder.RenameIndex(
                name: "IX_Notas_DisciplinaId",
                table: "Notas",
                newName: "IX_Notas_DisciplinaMatriculadaId");

            migrationBuilder.RenameColumn(
                name: "DisicplinaId",
                table: "DisciplinaMatriculada",
                newName: "DisicplinaProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_DisciplinaMatriculada_DisicplinaId",
                table: "DisciplinaMatriculada",
                newName: "IX_DisciplinaMatriculada_DisicplinaProfessorId");

            migrationBuilder.AlterColumn<double>(
                name: "Nota4",
                table: "Notas",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Nota3",
                table: "Notas",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Nota2",
                table: "Notas",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Nota1",
                table: "Notas",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Media",
                table: "Notas",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AprovadoReprovado",
                table: "Notas",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notas",
                table: "Notas",
                columns: new[] { "AlunoId", "DisciplinaMatriculadaId" });

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_AlunoId",
                table: "Matriculas",
                column: "AlunoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_TurmaId",
                table: "Matriculas",
                column: "TurmaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinaMatriculada_DisciplinaProfessor_DisicplinaProfessorId",
                table: "DisciplinaMatriculada",
                column: "DisicplinaProfessorId",
                principalTable: "DisciplinaProfessor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Alunos_AlunoId",
                table: "Matriculas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Turmas_TurmaId",
                table: "Matriculas",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_DisciplinaMatriculada_DisciplinaMatriculadaId",
                table: "Notas",
                column: "DisciplinaMatriculadaId",
                principalTable: "DisciplinaMatriculada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
