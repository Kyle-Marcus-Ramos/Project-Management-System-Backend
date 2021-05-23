using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Management.System.Data.Migrations
{
    public partial class AddProjectIdinCardTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Card",
                type: "Int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Card_ProjectId",
                table: "Card",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Project_ProjectId",
                table: "Card",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Project_ProjectId",
                table: "Card");

            migrationBuilder.DropIndex(
                name: "IX_Card_ProjectId",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Card");
        }
    }
}
