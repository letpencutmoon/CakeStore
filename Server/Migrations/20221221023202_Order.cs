using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CakeStore.Server.Migrations
{
    /// <inheritdoc />
    public partial class Order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CakeId = table.Column<int>(type: "int", nullable: false),
                    CakeTypeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => new { x.OrderId, x.CakeId, x.CakeTypeId });
                    table.ForeignKey(
                        name: "FK_OrderItem_CakeType_CakeTypeId",
                        column: x => x.CakeTypeId,
                        principalTable: "CakeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Cake_CakeId",
                        column: x => x.CakeId,
                        principalTable: "Cake",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 1, 3 },
                column: "OriginalPrice",
                value: 47.6m);

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 1, 4 },
                column: "OriginalPrice",
                value: 48.6m);

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 2, 2 },
                column: "OriginalPrice",
                value: 49.6m);

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 2, 3 },
                column: "OriginalPrice",
                value: 50.6m);

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 2, 4 },
                column: "OriginalPrice",
                value: 51.6m);

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 3, 2 },
                column: "OriginalPrice",
                value: 52.6m);

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 3, 3 },
                column: "OriginalPrice",
                value: 53.6m);

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 3, 4 },
                column: "OriginalPrice",
                value: 54.6m);

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 4, 2 },
                column: "OriginalPrice",
                value: 55.6m);

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 4, 3 },
                column: "OriginalPrice",
                value: 56.6m);

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 4, 4 },
                column: "OriginalPrice",
                value: 57.6m);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_CakeId",
                table: "OrderItem",
                column: "CakeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_CakeTypeId",
                table: "OrderItem",
                column: "CakeTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 1, 3 },
                column: "OriginalPrice",
                value: 46.6m);

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 1, 4 },
                column: "OriginalPrice",
                value: 46.6m);

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 2, 2 },
                column: "OriginalPrice",
                value: 46.6m);

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 2, 3 },
                column: "OriginalPrice",
                value: 46.6m);

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 2, 4 },
                column: "OriginalPrice",
                value: 46.6m);

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 3, 2 },
                column: "OriginalPrice",
                value: 46.6m);

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 3, 3 },
                column: "OriginalPrice",
                value: 58.6m);

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 3, 4 },
                column: "OriginalPrice",
                value: 46.6m);

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 4, 2 },
                column: "OriginalPrice",
                value: 46.6m);

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 4, 3 },
                column: "OriginalPrice",
                value: 46.6m);

            migrationBuilder.UpdateData(
                table: "CakeVariant",
                keyColumns: new[] { "CakeId", "CakeTypeId" },
                keyValues: new object[] { 4, 4 },
                column: "OriginalPrice",
                value: 46.6m);
        }
    }
}
