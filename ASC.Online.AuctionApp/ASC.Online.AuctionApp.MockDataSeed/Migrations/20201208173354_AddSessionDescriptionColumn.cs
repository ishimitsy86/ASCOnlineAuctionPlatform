using Microsoft.EntityFrameworkCore.Migrations;

namespace ASC.Online.AuctionApp.MockDataSeed.Migrations
{
    public partial class AddSessionDescriptionColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SessionDescription",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionDescription",
                table: "Sessions");
        }
    }
}
