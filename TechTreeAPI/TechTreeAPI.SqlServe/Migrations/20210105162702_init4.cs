using Microsoft.EntityFrameworkCore.Migrations;

namespace TechTreeAPI.SqlServe.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Cost",
                table: "Builds",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Cost",
                table: "Builds",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
