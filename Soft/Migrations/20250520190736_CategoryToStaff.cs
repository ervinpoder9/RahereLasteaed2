using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mvc.Soft.Migrations
{
    /// <inheritdoc />
    public partial class CategoryToStaff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AllCategoriesId",
                table: "AllStaff",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllCategoriesId",
                table: "AllStaff");
        }
    }
}
