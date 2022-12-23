using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CakeStore.Server.Migrations
{
    /// <inheritdoc />
    public partial class CategoryFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "IsDeleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "IsDeleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "IsDeleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "IsDeleted", "Visible" },
                values: new object[] { false, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "Category");
        }
    }
}
