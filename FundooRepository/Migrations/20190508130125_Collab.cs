using Microsoft.EntityFrameworkCore.Migrations;

namespace FundooRepository.Migrations
{
    public partial class Collab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collaborator_Notes_NotesModelId",
                table: "Collaborator");

            migrationBuilder.DropIndex(
                name: "IX_Collaborator_NotesModelId",
                table: "Collaborator");

            migrationBuilder.DropColumn(
                name: "NotesModelId",
                table: "Collaborator");

            migrationBuilder.AddColumn<bool>(
                name: "IsCollaborate",
                table: "Notes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCollaborate",
                table: "Notes");

            migrationBuilder.AddColumn<int>(
                name: "NotesModelId",
                table: "Collaborator",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Collaborator_NotesModelId",
                table: "Collaborator",
                column: "NotesModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collaborator_Notes_NotesModelId",
                table: "Collaborator",
                column: "NotesModelId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
