using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareConnect.Services.MentelHealthApi.Migrations
{
    /// <inheritdoc />
    public partial class updatingmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MoodTrackers",
                table: "MoodTrackers");

            migrationBuilder.AddColumn<int>(
                name: "EntryId",
                table: "MoodTrackers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoodTrackers",
                table: "MoodTrackers",
                column: "EntryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MoodTrackers",
                table: "MoodTrackers");

            migrationBuilder.DropColumn(
                name: "EntryId",
                table: "MoodTrackers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoodTrackers",
                table: "MoodTrackers",
                column: "EntryDate");
        }
    }
}
