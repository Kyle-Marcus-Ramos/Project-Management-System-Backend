using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Management.System.Data.Migrations
{
    public partial class addStatusInCardTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Card",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Card");
        }
    }
}
