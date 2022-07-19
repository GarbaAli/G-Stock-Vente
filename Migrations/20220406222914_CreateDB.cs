using Microsoft.EntityFrameworkCore.Migrations;

namespace G_Stock_Vente.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "General",
                columns: table => new
                {
                    reference = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    appNom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    devise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alerteJour = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_General", x => x.reference);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "General");
        }
    }
}
