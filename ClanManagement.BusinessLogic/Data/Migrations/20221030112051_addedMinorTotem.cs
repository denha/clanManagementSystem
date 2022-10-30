using Microsoft.EntityFrameworkCore.Migrations;

namespace ClanManagement.BusinessLogic.Data.Migrations
{
    public partial class addedMinorTotem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "clan_motto",
                table: "clan",
                newName: "motto_id");

            migrationBuilder.AddColumn<string>(
                name: "minor_totem",
                table: "clan",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "minor_totem",
                table: "clan");

            migrationBuilder.RenameColumn(
                name: "motto_id",
                table: "clan",
                newName: "clan_motto");
        }
    }
}
