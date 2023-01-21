using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClanManagement.BusinessLogic.Migrations
{
    public partial class newDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clan",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clan_leader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    totem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    minor_totem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MottoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    clan_seat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lang_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clan", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Name",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clan_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Name", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ClanMotto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    motto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClanId = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClanMotto", x => x.id);
                    table.ForeignKey(
                        name: "FK_ClanMotto_Clan_ClanId",
                        column: x => x.ClanId,
                        principalTable: "Clan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClanMotto_ClanId",
                table: "ClanMotto",
                column: "ClanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClanMotto");

            migrationBuilder.DropTable(
                name: "Name");

            migrationBuilder.DropTable(
                name: "Clan");
        }
    }
}
