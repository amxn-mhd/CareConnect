using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareConnect.Services.MentelHealthApi.Migrations
{
    /// <inheritdoc />
    public partial class MentalHealth_Update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EntryTime",
                table: "MoodTracker",
                newName: "EntryDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EntryDate",
                table: "MoodTracker",
                newName: "EntryTime");
        }
    }
}
