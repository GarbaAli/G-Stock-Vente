using Microsoft.EntityFrameworkCore.Migrations;

namespace G_Stock_Vente.Migrations
{
    public partial class AddClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "libelleUnite",
                table: "Unites",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "codeUnite",
                table: "Unites",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    clientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codeClt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nomClt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emailClt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneClt = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    postalClt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    paysClt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    villeClt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    statutClt = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.clientId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "libelleUnite",
                table: "Unites",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "codeUnite",
                table: "Unites",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);
        }
    }
}
