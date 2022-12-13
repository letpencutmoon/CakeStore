using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CakeStore.Server.Migrations
{
    /// <inheritdoc />
    public partial class Category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Cake",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Cake",
                keyColumn: "ID",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Cake",
                keyColumn: "ID",
                keyValue: 2,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Cake",
                keyColumn: "ID",
                keyValue: 3,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Cake",
                keyColumn: "ID",
                keyValue: 4,
                column: "CategoryId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "ID", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "蛋糕", "OrdinaryCake" },
                    { 2, "生日蛋糕", "BirthdayCake" },
                    { 3, "面包", "Bread" },
                    { 4, "饼干", "Cookie" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cake_CategoryId",
                table: "Cake",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cake_Category_CategoryId",
                table: "Cake",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cake_Category_CategoryId",
                table: "Cake");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Cake_CategoryId",
                table: "Cake");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Cake");
        }
    }
}
