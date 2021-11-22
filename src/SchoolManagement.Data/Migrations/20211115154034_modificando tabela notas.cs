using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class modificandotabelanotas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Notas",
                table: "Notas");

            migrationBuilder.AddColumn<long>(
                name: "DisciplinaMatriculadaId",
                table: "Notas",
                type: "BIGINT",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notas",
                table: "Notas",
                columns: new[] { "AlunoId", "DisciplinaMatriculadaId" });

            migrationBuilder.CreateIndex(
                name: "IX_Notas_DisciplinaMatriculadaId",
                table: "Notas",
                column: "DisciplinaMatriculadaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_DisciplinaMatriculada_DisciplinaMatriculadaId",
                table: "Notas",
                column: "DisciplinaMatriculadaId",
                principalTable: "DisciplinaMatriculada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_DisciplinaMatriculada_DisciplinaMatriculadaId",
                table: "Notas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notas",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_DisciplinaMatriculadaId",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "DisciplinaMatriculadaId",
                table: "Notas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notas",
                table: "Notas",
                column: "AlunoId");
        }
    }
}
