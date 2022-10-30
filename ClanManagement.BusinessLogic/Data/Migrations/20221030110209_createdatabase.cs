using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClanManagement.BusinessLogic.Data.Migrations
{
    public partial class createdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clan",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clan_leader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    totem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    clan_motto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    clan_seat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clan", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clan");
        }
    }
}
