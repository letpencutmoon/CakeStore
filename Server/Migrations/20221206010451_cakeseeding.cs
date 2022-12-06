using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CakeStore.Server.Migrations
{
    /// <inheritdoc />
    public partial class cakeseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cake",
                columns: new[] { "ID", "Description", "Imgurl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "啊吧啊吧啊吧", "https://imagecdn.lapetit.cn/postsystem/docroot/images/goods/201212/10800/list_10800.jpg", "雪域牛乳芝士", 56.99m },
                    { 2, "啊吧啊吧啊吧", "https://imagecdn.lapetit.cn/postsystem/docroot/images/goods/201310/12287/list_12287.jpg?v=1666669194", "环游世界", 56.99m },
                    { 3, "啊吧啊吧啊吧", "https://imagecdn.lapetit.cn/postsystem/docroot/images/promotion/202207/9AF4E9159E7B708C3437781A69A6B62B.jpg", "云朵芒芒", 56.99m },
                    { 4, "啊吧啊吧啊吧", "https://imagecdn.lapetit.cn/postsystem/docroot/images/promotion/202209/2038FF4F22F25BC9A02A61B65851B028.jpg", "星云知秋", 56.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cake",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cake",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cake",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cake",
                keyColumn: "ID",
                keyValue: 4);
        }
    }
}
