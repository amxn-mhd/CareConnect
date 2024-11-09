using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareConnect.Services.MentelHealthApi.Migrations
{
    /// <inheritdoc />
    public partial class MentalHealth_Update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MoodTracker",
                table: "MoodTracker");

            migrationBuilder.DropColumn(
                name: "Diagnosis",
                table: "MoodTracker");

            migrationBuilder.DropColumn(
                name: "History",
                table: "MoodTracker");

            migrationBuilder.RenameTable(
                name: "MoodTracker",
                newName: "MoodTrackers");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "EntryDate",
                table: "MoodTrackers",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoodTrackers",
                table: "MoodTrackers",
                column: "EntryDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MoodTrackers",
                table: "MoodTrackers");

            migrationBuilder.RenameTable(
                name: "MoodTrackers",
                newName: "MoodTracker");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryDate",
                table: "MoodTracker",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "Diagnosis",
                table: "MoodTracker",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "History",
                table: "MoodTracker",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoodTracker",
                table: "MoodTracker",
                column: "EntryDate");
        }
    }
}
