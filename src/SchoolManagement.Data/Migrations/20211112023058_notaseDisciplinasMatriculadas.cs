using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class notaseDisciplinasMatriculadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DisciplinasMatriculadas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessorId = table.Column<long>(type: "BIGINT", nullable: false),
                    DisciplinaId = table.Column<long>(type: "BIGINT", nullable: false),
                    Dia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Horario = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                        name: "FK_DisciplinasMatriculadas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinasMatriculadas_DisciplinaId",
                table: "DisciplinasMatriculadas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinasMatriculadas_ProfessorId",
                table: "DisciplinasMatriculadas",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisciplinasMatriculadas");
        }
    }
}
