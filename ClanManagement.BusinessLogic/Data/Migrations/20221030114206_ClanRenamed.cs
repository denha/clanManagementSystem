using Microsoft.EntityFrameworkCore.Migrations;

namespace ClanManagement.BusinessLogic.Data.Migrations
{
    public partial class ClanRenamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_clan",
                table: "clan");

            migrationBuilder.RenameTable(
                name: "clan",
                newName: "Clan");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clan",
                table: "Clan",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Clan",
                table: "Clan");

            migrationBuilder.RenameTable(
                name: "Clan",
                newName: "clan");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clan",
                table: "clan",
                column: "id");
        }
    }
}
