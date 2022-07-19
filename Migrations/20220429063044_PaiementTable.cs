using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace G_Stock_Vente.Migrations
{
    public partial class PaiementTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "paiements",
                columns: table => new
                {
                    paiementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    libellePaiement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cdepaiement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    statutPaiement = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paiements", x => x.paiementId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "paiements");
        }
    }
}
