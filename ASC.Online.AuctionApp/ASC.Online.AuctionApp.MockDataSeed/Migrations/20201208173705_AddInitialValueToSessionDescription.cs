using Microsoft.EntityFrameworkCore.Migrations;

namespace ASC.Online.AuctionApp.MockDataSeed.Migrations
{
    public partial class AddInitialValueToSessionDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "SessionDescription",
                value: "This session is being held as a tribute to santa!!!");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "SessionDescription",
                value: null);
        }
    }
}
