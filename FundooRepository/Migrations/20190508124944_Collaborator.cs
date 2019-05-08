using Microsoft.EntityFrameworkCore.Migrations;

namespace FundooRepository.Migrations
{
    public partial class Collaborator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollabModelId",
                table: "Notes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CollabModelId",
                table: "Notes",
                column: "CollabModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Collaborator_CollabModelId",
                table: "Notes",
                column: "CollabModelId",
                principalTable: "Collaborator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Collaborator_CollabModelId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_CollabModelId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "CollabModelId",
                table: "Notes");
        }
    }
}
