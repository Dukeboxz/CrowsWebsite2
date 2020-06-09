using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowsWebsite.Migrations
{
    public partial class addedLikeToPlayJoin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberLikeToPlayGames",
                columns: table => new
                {
                    MemberId = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberLikeToPlayGames", x => new { x.MemberId, x.GameId });
                    table.ForeignKey(
                        name: "FK_MemberLikeToPlayGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberLikeToPlayGames_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberLikeToPlayGames_GameId",
                table: "MemberLikeToPlayGames",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberLikeToPlayGames");
        }
    }
}
