using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class AdicionandoDisciplinasMatriculadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DisciplinaMatriculada",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisicplinaProfessorId = table.Column<long>(type: "BIGINT", nullable: false),
                    MatriculaId = table.Column<long>(type: "BIGINT", nullable: false),
                    Horario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinaMatriculada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisciplinaMatriculada_DisciplinaProfessor_DisicplinaProfessorId",
                        column: x => x.DisicplinaProfessorId,
                        principalTable: "DisciplinaProfessor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinaMatriculada_Matriculas_MatriculaId",
                        column: x => x.MatriculaId,
                        principalTable: "Matriculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaMatriculada_DisicplinaProfessorId",
                table: "DisciplinaMatriculada",
                column: "DisicplinaProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaMatriculada_MatriculaId",
                table: "DisciplinaMatriculada",
                column: "MatriculaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisciplinaMatriculada");
        }
    }
}
