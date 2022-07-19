using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace G_Stock_Vente.Migrations
{
    public partial class addDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dte_creation",
                table: "General",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modification",
                table: "General",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dte_creation",
                table: "General");

            migrationBuilder.DropColumn(
                name: "last_modification",
                table: "General");
        }
    }
}
