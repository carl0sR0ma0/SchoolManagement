using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class CriandoTabelaDisciplina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sigla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargaHoraria = table.Column<int>(type: "int", nullable: false),
                    ConteudoProgramatico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ementa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AulasSemanais = table.Column<int>(type: "int", nullable: false),
                    FaltasPermitidas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disciplinas");
        }
    }
}
