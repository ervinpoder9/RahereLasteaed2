using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mvc.Soft.Migrations
{
    /// <inheritdoc />
    public partial class AddAbsenceCreatedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubmissionDate",
                table: "Absence",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Absence",
                newName: "SubmissionDate");
        }
    }
}
