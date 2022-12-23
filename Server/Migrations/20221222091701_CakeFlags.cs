using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CakeStore.Server.Migrations
{
    /// <inheritdoc />
    public partial class CakeFlags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CakeVariant",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "CakeVariant",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Cake",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "Cake",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Cake",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "IsDeleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Cake",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "IsDeleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Cake",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "IsDeleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Cake",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "IsDeleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "IsDeleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "IsDeleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "IsDeleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "IsDeleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 2, 3 },
                columns: new[] { "IsDeleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 2, 4 },
                columns: new[] { "IsDeleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 3, 2 },
                columns: new[] { "IsDeleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 3, 3 },
                columns: new[] { "IsDeleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 3, 4 },
                columns: new[] { "IsDeleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 4, 2 },
                columns: new[] { "IsDeleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 4, 3 },
                columns: new[] { "IsDeleted", "Visible" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 4, 4 },
                columns: new[] { "IsDeleted", "Visible" },
                values: new object[] { false, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CakeVariant");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "CakeVariant");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cake");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "Cake");
        }
    }
}
