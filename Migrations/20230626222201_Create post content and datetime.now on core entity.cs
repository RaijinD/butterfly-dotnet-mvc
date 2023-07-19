using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace butterfly_dotnet_mvc.Migrations
{
    /// <inheritdoc />
    public partial class Createpostcontentanddatetimenowoncoreentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "content",
                table: "Posts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "content",
                table: "Posts");
        }
    }
}
