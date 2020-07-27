using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowsWebsite.Migrations
{
    public partial class addGamingSessionDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "GamingSessions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "GamingSessions");
        }
    }
}
