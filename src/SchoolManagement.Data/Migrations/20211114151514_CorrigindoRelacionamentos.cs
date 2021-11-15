using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class CorrigindoRelacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_DisciplinasMatriculadas_DisciplinaId",
                table: "Notas");

            migrationBuilder.DropTable(
                name: "DisciplinasMatriculadas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notas",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_DisciplinaId",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "DisciplinaId",
                table: "Notas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notas",
                table: "Notas",
                column: "AlunoId");

            migrationBuilder.CreateTable(
                name: "DisciplinaProfessor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessorId = table.Column<long>(type: "BIGINT", nullable: false),
                    DisciplinaId = table.Column<long>(type: "BIGINT", nullable: false),
                    Dia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Horario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinaProfessor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisciplinaProfessor_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinaProfessor_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaProfessor_DisciplinaId",
                table: "DisciplinaProfessor",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaProfessor_ProfessorId",
                table: "DisciplinaProfessor",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisciplinaProfessor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notas",
                table: "Notas");

            migrationBuilder.AddColumn<long>(
                name: "DisciplinaId",
                table: "Notas",
                type: "BIGINT",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notas",
                table: "Notas",
                columns: new[] { "AlunoId", "DisciplinaId" });

            migrationBuilder.CreateTable(
                name: "DisciplinasMatriculadas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisciplinaId = table.Column<long>(type: "BIGINT", nullable: false),
                    Horario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatriculaId = table.Column<long>(type: "BIGINT", nullable: false),
                    ProfessorId = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinasMatriculadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisciplinasMatriculadas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinasMatriculadas_Matriculas_MatriculaId",
                        column: x => x.MatriculaId,
                        principalTable: "Matriculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinasMatriculadas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notas_DisciplinaId",
                table: "Notas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinasMatriculadas_DisciplinaId",
                table: "DisciplinasMatriculadas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinasMatriculadas_MatriculaId",
                table: "DisciplinasMatriculadas",
                column: "MatriculaId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinasMatriculadas_ProfessorId",
                table: "DisciplinasMatriculadas",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_DisciplinasMatriculadas_DisciplinaId",
                table: "Notas",
                column: "DisciplinaId",
                principalTable: "DisciplinasMatriculadas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
