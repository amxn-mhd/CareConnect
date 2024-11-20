using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareConnect.Services.SafetyApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStringSafety : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportIncident",
                table: "ReportIncident");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ReportIncident",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IncidentId",
                table: "ReportIncident",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "AuthorizeEdit",
                table: "ReportIncident",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportIncident",
                table: "ReportIncident",
                column: "IncidentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportIncident",
                table: "ReportIncident");

            migrationBuilder.DropColumn(
                name: "IncidentId",
                table: "ReportIncident");

            migrationBuilder.DropColumn(
                name: "AuthorizeEdit",
                table: "ReportIncident");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ReportIncident",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportIncident",
                table: "ReportIncident",
                column: "EntryDate");
        }
    }
}
