using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASC.Online.AuctionApp.MockDataSeed.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfItems = table.Column<int>(type: "int", nullable: false),
                    SessionStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedMemberId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedMemberId = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "CreatedMemberId", "ModifiedBy", "ModifiedDate", "ModifiedMemberId", "NumberOfItems", "SessionEndDate", "SessionName", "SessionStartDate", "SessionStatus" },
                values: new object[] { 1L, "Jaimy Solovin", new DateTime(2020, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, "Jaimy Solovin", new DateTime(2020, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 2, new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mistory Hunt", new DateTime(2020, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessions");
        }
    }
}
