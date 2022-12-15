using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CakeStore.Server.Migrations
{
    /// <inheritdoc />
    public partial class CakeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Cake");

            migrationBuilder.CreateTable(
                name: "CakeType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CakeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CakeSize",
                columns: table => new
                {
                    CakeId = table.Column<int>(type: "int", nullable: false),
                    CakeTypeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CakeSize", x => new { x.CakeId, x.CakeTypeId });
                    table.ForeignKey(
                        name: "FK_CakeSize_CakeType_CakeTypeId",
                        column: x => x.CakeTypeId,
                        principalTable: "CakeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CakeSize_Cake_CakeId",
                        column: x => x.CakeId,
                        principalTable: "Cake",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CakeType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Default" },
                    { 2, "4寸" },
                    { 3, "6寸" },
                    { 4, "8寸" }
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 2,
                column: "Url",
                value: "BirthdayCake");

            migrationBuilder.InsertData(
                table: "CakeSize",
                columns: new[] { "CakeId", "CakeTypeId", "OriginalPrice", "Price" },
                values: new object[,]
                {
                    { 1, 2, 46.6m, 58.6m },
                    { 1, 3, 46.6m, 58.6m },
                    { 1, 4, 46.6m, 58.6m },
                    { 2, 2, 46.6m, 58.6m },
                    { 2, 3, 46.6m, 58.6m },
                    { 2, 4, 46.6m, 58.6m },
                    { 3, 2, 46.6m, 58.6m },
                    { 3, 3, 58.6m, 58.6m },
                    { 3, 4, 46.6m, 58.6m },
                    { 4, 2, 46.6m, 58.6m },
                    { 4, 3, 46.6m, 58.6m },
                    { 4, 4, 46.6m, 58.6m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CakeSize_CakeTypeId",
                table: "CakeSize",
                column: "CakeTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CakeSize");

            migrationBuilder.DropTable(
                name: "CakeType");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Cake",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Cake",
                keyColumn: "ID",
                keyValue: 1,
                column: "Price",
                value: 56.99m);

            migrationBuilder.UpdateData(
                table: "Cake",
                keyColumn: "ID",
                keyValue: 2,
                column: "Price",
                value: 56.99m);

            migrationBuilder.UpdateData(
                table: "Cake",
                keyColumn: "ID",
                keyValue: 3,
                column: "Price",
                value: 56.99m);

            migrationBuilder.UpdateData(
                table: "Cake",
                keyColumn: "ID",
                keyValue: 4,
                column: "Price",
                value: 56.99m);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "ID",
                keyValue: 2,
                column: "Url",
                value: "birthdayCake");
        }
    }
}
