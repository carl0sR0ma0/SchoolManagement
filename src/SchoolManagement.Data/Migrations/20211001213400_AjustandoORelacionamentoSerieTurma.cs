using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class AjustandoORelacionamentoSerieTurma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SerieId",
                table: "Turmas",
                type: "BIGINT",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_SerieId",
                table: "Turmas",
                column: "SerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Series_SerieId",
                table: "Turmas",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Series_SerieId",
                table: "Turmas");

            migrationBuilder.DropIndex(
                name: "IX_Turmas_SerieId",
                table: "Turmas");

            migrationBuilder.DropColumn(
                name: "SerieId",
                table: "Turmas");
        }
    }
}
