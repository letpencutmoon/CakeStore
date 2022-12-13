namespace CakeStore.Server.Data
{
    public class DataContext:DbContext
    {
        #pragma warning disable CS8618
        public DataContext(DbContextOptions<DataContext> options):base(options)
        #pragma warning restore CS8618
        {
        }

        public DbSet<Cake> Cake { get; set; }

        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    ID = 1,
                    Name = "蛋糕",
                    Url = "OrdinaryCake"
                },
                new Category()
                {
                    ID = 2,
                    Name = "生日蛋糕",
                    Url = "BirthdayCake"
                },
                new Category()
                {
                    ID = 3,
                    Name = "面包",
                    Url = "Bread"
                },
                new Category()
                {
                    ID = 4,
                    Name = "饼干",
                    Url = "Cookie"
                }
                );

            modelBuilder.Entity<Cake>().HasData(
                new Cake
                {
                    ID = 1,
                    Name = "雪域牛乳芝士",
                    Description = "啊吧啊吧啊吧",
                    Imgurl = "https://imagecdn.lapetit.cn/postsystem/docroot/images/goods/201212/10800/list_10800.jpg",
                    Price = 56.99m,
                    CategoryId = 1
                },
                new Cake
                {
                    ID = 2,
                    Name = "环游世界",
                    Description = "啊吧啊吧啊吧",
                    Imgurl = "https://imagecdn.lapetit.cn/postsystem/docroot/images/goods/201310/12287/list_12287.jpg?v=1666669194",
                    Price = 56.99m,
                    CategoryId = 1
                },
                new Cake
                {
                    ID = 3,
                    Name = "云朵芒芒",
                    Description = "啊吧啊吧啊吧",
                    Imgurl = "https://imagecdn.lapetit.cn/postsystem/docroot/images/promotion/202207/9AF4E9159E7B708C3437781A69A6B62B.jpg",
                    Price = 56.99m,
                    CategoryId = 1
                },
                new Cake
                {
                    ID = 4,
                    Name = "星云知秋",
                    Description = "啊吧啊吧啊吧",
                    Imgurl = "https://imagecdn.lapetit.cn/postsystem/docroot/images/promotion/202209/2038FF4F22F25BC9A02A61B65851B028.jpg",
                    Price = 56.99m,
                    CategoryId = 1
                }
            );
        }
    }
}
