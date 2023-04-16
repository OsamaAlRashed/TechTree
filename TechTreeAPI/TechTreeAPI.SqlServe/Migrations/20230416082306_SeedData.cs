using Microsoft.EntityFrameworkCore.Migrations;

namespace TechTreeAPI.SqlServe.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Builds",
                columns: new[] { "Id", "BuildName", "Cost", "MaxCount" },
                values: new object[,]
                {
                    { 1, "CommandCenter", 1000, 1 },
                    { 2, "Power", 1200, 2 },
                    { 3, "Barracks", 1300, 1 },
                    { 4, "Defences", 1100, 3 },
                    { 5, "Mine", 1500, 2 },
                    { 6, "Airport", 2000, 2 },
                    { 7, "WarFactory", 1500, 3 },
                    { 8, "StrategyCenter", 1700, 1 },
                    { 9, "Hospital", 2500, 1 },
                    { 10, "Radar", 900, 10 },
                    { 11, "NuclearPower", 4000, 1 },
                    { 12, "SuperWeapon", 2500, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
