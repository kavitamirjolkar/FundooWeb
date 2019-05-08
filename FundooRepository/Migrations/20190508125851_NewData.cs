using Microsoft.EntityFrameworkCore.Migrations;

namespace FundooRepository.Migrations
{
    public partial class NewData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
