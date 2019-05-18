namespace FundooRepository.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <summary>
    /// migration class
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Migrations.Migration" />
    public partial class NewData : Migration
    {     
        /// <summary>
        /// <para>
        /// Builds the operations that will migrate the database 'up'.
        /// </para>
        /// <para>
        /// That is, builds the operations that will take the database from the state left in by the
        /// previous migration so that it is up-to-date with regard to this migration.
        /// </para>
        /// <para>
        /// This method must be overridden in each class the inherits from <see cref="T:Microsoft.EntityFrameworkCore.Migrations.Migration" />.
        /// </para>
        /// </summary>
        /// <param name="migrationBuilder">The <see cref="T:Microsoft.EntityFrameworkCore.Migrations.MigrationBuilder" /> that will build the operations.</param>
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

        /// <summary>
        /// <para>
        /// Builds the operations that will migrate the database 'down'.
        /// </para>
        /// <para>
        /// That is, builds the operations that will take the database from the state left in by
        /// this migration so that it returns to the state that it was in before this migration was applied.
        /// </para>
        /// <para>
        /// This method must be overridden in each class the inherits from <see cref="T:Microsoft.EntityFrameworkCore.Migrations.Migration" /> if
        /// both 'up' and 'down' migrations are to be supported. If it is not overridden, then calling it
        /// will throw and it will not be possible to migrate in the 'down' direction.
        /// </para>
        /// </summary>
        /// <param name="migrationBuilder">The <see cref="T:Microsoft.EntityFrameworkCore.Migrations.MigrationBuilder" /> that will build the operations.</param>
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
