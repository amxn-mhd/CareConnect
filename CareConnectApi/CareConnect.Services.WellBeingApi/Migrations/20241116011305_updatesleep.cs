using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareConnect.Services.WellBeingApi.Migrations
{
    /// <inheritdoc />
    public partial class updatesleep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SleepAnalyser",
                table: "SleepAnalyser");

            migrationBuilder.AddColumn<int>(
                name: "EntryId",
                table: "SleepAnalyser",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SleepAnalyser",
                table: "SleepAnalyser",
                column: "EntryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SleepAnalyser",
                table: "SleepAnalyser");

            migrationBuilder.DropColumn(
                name: "EntryId",
                table: "SleepAnalyser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SleepAnalyser",
                table: "SleepAnalyser",
                column: "EntryDate");
        }
    }
}
