using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowsWebsite.Migrations
{
    public partial class initCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GamingSessions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfSession = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamingSessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GamesBeingPlayed",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(nullable: true),
                    SpacesAvailable = table.Column<int>(nullable: false),
                    GamingSessionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesBeingPlayed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamesBeingPlayed_GamingSessions_GamingSessionId",
                        column: x => x.GamingSessionId,
                        principalTable: "GamingSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    SecondName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    GamesBeingPlayedId = table.Column<int>(nullable: true),
                    GamingSessionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Members_GamesBeingPlayed_GamesBeingPlayedId",
                        column: x => x.GamesBeingPlayedId,
                        principalTable: "GamesBeingPlayed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Members_GamingSessions_GamingSessionId",
                        column: x => x.GamingSessionId,
                        principalTable: "GamingSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiId = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    min_players = table.Column<int>(nullable: false),
                    max_players = table.Column<int>(nullable: false),
                    min_playtime = table.Column<int>(nullable: false),
                    max_playtime = table.Column<int>(nullable: false),
                    img_url = table.Column<string>(nullable: true),
                    rules_url = table.Column<string>(nullable: true),
                    MemberId = table.Column<int>(nullable: true),
                    MemberId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Members_MemberId1",
                        column: x => x.MemberId1,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberOwnedGames",
                columns: table => new
                {
                    MemberId = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberOwnedGames", x => new { x.MemberId, x.GameId });
                    table.ForeignKey(
                        name: "FK_MemberOwnedGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberOwnedGames_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_MemberId",
                table: "Games",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_MemberId1",
                table: "Games",
                column: "MemberId1");

            migrationBuilder.CreateIndex(
                name: "IX_GamesBeingPlayed_GameId",
                table: "GamesBeingPlayed",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesBeingPlayed_GamingSessionId",
                table: "GamesBeingPlayed",
                column: "GamingSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberOwnedGames_GameId",
                table: "MemberOwnedGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_GamesBeingPlayedId",
                table: "Members",
                column: "GamesBeingPlayedId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_GamingSessionId",
                table: "Members",
                column: "GamingSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_GamesBeingPlayed_Games_GameId",
                table: "GamesBeingPlayed",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Members_MemberId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Members_MemberId1",
                table: "Games");

            migrationBuilder.DropTable(
                name: "MemberOwnedGames");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "GamesBeingPlayed");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "GamingSessions");
        }
    }
}
