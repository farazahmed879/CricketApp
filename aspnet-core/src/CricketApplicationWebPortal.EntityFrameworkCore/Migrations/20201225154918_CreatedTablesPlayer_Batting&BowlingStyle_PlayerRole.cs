using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CricketApplicationWebPortal.Migrations
{
    public partial class CreatedTablesPlayer_BattingBowlingStyle_PlayerRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Teams",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Teams",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Teams",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRegistered",
                table: "Teams",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Teams",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BattingStyles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattingStyles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BowlingStyles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BowlingStyles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    PlayerName = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    CNIC = table.Column<string>(nullable: true),
                    BattingStyleId = table.Column<int>(nullable: true),
                    BowlingStyleId = table.Column<int>(nullable: true),
                    TeamId = table.Column<long>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: true),
                    PlayerRoleId = table.Column<int>(nullable: true),
                    IsGuestorRegistered = table.Column<string>(nullable: true),
                    IsDeactivated = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_BattingStyles_BattingStyleId",
                        column: x => x.BattingStyleId,
                        principalTable: "BattingStyles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_BowlingStyles_BowlingStyleId",
                        column: x => x.BowlingStyleId,
                        principalTable: "BowlingStyles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_PlayerRoles_PlayerRoleId",
                        column: x => x.PlayerRoleId,
                        principalTable: "PlayerRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_BattingStyleId",
                table: "Players",
                column: "BattingStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_BowlingStyleId",
                table: "Players",
                column: "BowlingStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerRoleId",
                table: "Players",
                column: "PlayerRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "BattingStyles");

            migrationBuilder.DropTable(
                name: "BowlingStyles");

            migrationBuilder.DropTable(
                name: "PlayerRoles");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "IsRegistered",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Teams");
        }
    }
}
