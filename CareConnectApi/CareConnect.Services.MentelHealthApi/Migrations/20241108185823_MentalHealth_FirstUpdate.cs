using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareConnect.Services.MentelHealthApi.Migrations
{
    /// <inheritdoc />
    public partial class MentalHealth_FirstUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoodTracker",
                columns: table => new
                {
                    EntryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    History = table.Column<bool>(type: "bit", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CurrentMood = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DoctorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoodTracker", x => x.EntryTime);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoodTracker");
        }
    }
}
