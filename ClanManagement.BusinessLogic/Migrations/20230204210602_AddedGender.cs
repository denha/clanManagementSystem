using Microsoft.EntityFrameworkCore.Migrations;

namespace ClanManagement.BusinessLogic.Migrations
{
    public partial class AddedGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Name",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Name");
        }
    }
}
