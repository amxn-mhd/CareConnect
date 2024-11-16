using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareConnect.Services.WellBeingApi.Migrations
{
    /// <inheritdoc />
    public partial class updatereminder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReminderScheduler",
                table: "ReminderScheduler");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ReminderScheduler",
                newName: "Task");

            migrationBuilder.AddColumn<int>(
                name: "Totalreminders",
                table: "ReminderScheduler",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReminderScheduler",
                table: "ReminderScheduler",
                column: "Totalreminders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReminderScheduler",
                table: "ReminderScheduler");

            migrationBuilder.DropColumn(
                name: "Totalreminders",
                table: "ReminderScheduler");

            migrationBuilder.RenameColumn(
                name: "Task",
                table: "ReminderScheduler",
                newName: "Title");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReminderScheduler",
                table: "ReminderScheduler",
                column: "EntryDate");
        }
    }
}
