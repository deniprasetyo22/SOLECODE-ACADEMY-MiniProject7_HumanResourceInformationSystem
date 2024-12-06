using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniProject7.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnFileAndTotaldays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "file",
                table: "leaverequest",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "totaldays",
                table: "leaverequest",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "file",
                table: "leaverequest");

            migrationBuilder.DropColumn(
                name: "totaldays",
                table: "leaverequest");
        }
    }
}
