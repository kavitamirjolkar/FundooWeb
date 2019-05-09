namespace FundooRepository.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;
    /// <summary>
    /// this is migrated class
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Migrations.Migration" />
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCollaborate",
                table: "Notes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCollaborate",
                table: "Notes",
                nullable: false,
                defaultValue: false);
        }
    }
}
