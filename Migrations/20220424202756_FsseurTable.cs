using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace G_Stock_Vente.Migrations
{
    public partial class FsseurTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "codeClt",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.CreateTable(
                name: "fournisseurs",
                columns: table => new
                {
                    FsseurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codeFsseur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nomFsseur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emailFsseur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneFsseur = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    postalFsseur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    paysFsseur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    villeFsseur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    statutFsseur = table.Column<bool>(type: "bit", nullable: false),
                    createdFsseur = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fournisseurs", x => x.FsseurId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fournisseurs");

            migrationBuilder.AlterColumn<string>(
                name: "codeClt",
                table: "Clients",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
