using Microsoft.EntityFrameworkCore.Migrations;

namespace ClanManagement.BusinessLogic.Migrations
{
    public partial class changedNameEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "clan_id",
                table: "Name",
                newName: "ClanId");

            migrationBuilder.AlterColumn<int>(
                name: "ClanId",
                table: "Name",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Name_ClanId",
                table: "Name",
                column: "ClanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Name_Clan_ClanId",
                table: "Name",
                column: "ClanId",
                principalTable: "Clan",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Name_Clan_ClanId",
                table: "Name");

            migrationBuilder.DropIndex(
                name: "IX_Name_ClanId",
                table: "Name");

            migrationBuilder.RenameColumn(
                name: "ClanId",
                table: "Name",
                newName: "clan_id");

            migrationBuilder.AlterColumn<string>(
                name: "clan_id",
                table: "Name",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
