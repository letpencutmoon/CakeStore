﻿// <auto-generated />
using System;
using CakeStore.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CakeStore.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221222025610_UserRole")]
    partial class UserRole
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CakeStore.Shared.Model.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("CakeStore.Shared.Model.Cake", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imgurl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryId");

                    b.ToTable("Cake");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CategoryId = 1,
                            Description = "啊吧啊吧啊吧",
                            Imgurl = "https://imagecdn.lapetit.cn/postsystem/docroot/images/goods/201212/10800/list_10800.jpg",
                            Name = "雪域牛乳芝士"
                        },
                        new
                        {
                            ID = 2,
                            CategoryId = 1,
                            Description = "啊吧啊吧啊吧",
                            Imgurl = "https://imagecdn.lapetit.cn/postsystem/docroot/images/goods/201310/12287/list_12287.jpg?v=1666669194",
                            Name = "环游世界"
                        },
                        new
                        {
                            ID = 3,
                            CategoryId = 1,
                            Description = "啊吧啊吧啊吧",
                            Imgurl = "https://imagecdn.lapetit.cn/postsystem/docroot/images/promotion/202207/9AF4E9159E7B708C3437781A69A6B62B.jpg",
                            Name = "云朵芒芒"
                        },
                        new
                        {
                            ID = 4,
                            CategoryId = 1,
                            Description = "啊吧啊吧啊吧",
                            Imgurl = "https://imagecdn.lapetit.cn/postsystem/docroot/images/promotion/202209/2038FF4F22F25BC9A02A61B65851B028.jpg",
                            Name = "星云知秋"
                        });
                });

            modelBuilder.Entity("CakeStore.Shared.Model.CakeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CakeType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Default"
                        },
                        new
                        {
                            Id = 2,
                            Name = "4寸"
                        },
                        new
                        {
                            Id = 3,
                            Name = "6寸"
                        },
                        new
                        {
                            Id = 4,
                            Name = "8寸"
                        });
                });

            modelBuilder.Entity("CakeStore.Shared.Model.CakeVariant", b =>
                {
                    b.Property<int>("CakeId")
                        .HasColumnType("int");

                    b.Property<int>("CakeTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CakeId", "CakeTypeId");

                    b.HasIndex("CakeTypeId");

                    b.ToTable("CakeVariant");

                    b.HasData(
                        new
                        {
                            CakeId = 1,
                            CakeTypeId = 2,
                            OriginalPrice = 46.6m,
                            Price = 58.6m
                        },
                        new
                        {
                            CakeId = 1,
                            CakeTypeId = 3,
                            OriginalPrice = 47.6m,
                            Price = 58.6m
                        },
                        new
                        {
                            CakeId = 1,
                            CakeTypeId = 4,
                            OriginalPrice = 48.6m,
                            Price = 58.6m
                        },
                        new
                        {
                            CakeId = 2,
                            CakeTypeId = 2,
                            OriginalPrice = 49.6m,
                            Price = 58.6m
                        },
                        new
                        {
                            CakeId = 2,
                            CakeTypeId = 3,
                            OriginalPrice = 50.6m,
                            Price = 58.6m
                        },
                        new
                        {
                            CakeId = 2,
                            CakeTypeId = 4,
                            OriginalPrice = 51.6m,
                            Price = 58.6m
                        },
                        new
                        {
                            CakeId = 3,
                            CakeTypeId = 2,
                            OriginalPrice = 52.6m,
                            Price = 58.6m
                        },
                        new
                        {
                            CakeId = 3,
                            CakeTypeId = 3,
                            OriginalPrice = 53.6m,
                            Price = 58.6m
                        },
                        new
                        {
                            CakeId = 3,
                            CakeTypeId = 4,
                            OriginalPrice = 54.6m,
                            Price = 58.6m
                        },
                        new
                        {
                            CakeId = 4,
                            CakeTypeId = 2,
                            OriginalPrice = 55.6m,
                            Price = 58.6m
                        },
                        new
                        {
                            CakeId = 4,
                            CakeTypeId = 3,
                            OriginalPrice = 56.6m,
                            Price = 58.6m
                        },
                        new
                        {
                            CakeId = 4,
                            CakeTypeId = 4,
                            OriginalPrice = 57.6m,
                            Price = 58.6m
                        });
                });

            modelBuilder.Entity("CakeStore.Shared.Model.CartItem", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CakeId")
                        .HasColumnType("int");

                    b.Property<int>("CakeTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("UserId", "CakeId", "CakeTypeId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("CakeStore.Shared.Model.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "蛋糕",
                            Url = "OrdinaryCake"
                        },
                        new
                        {
                            ID = 2,
                            Name = "生日蛋糕",
                            Url = "BirthdayCake"
                        },
                        new
                        {
                            ID = 3,
                            Name = "面包",
                            Url = "Bread"
                        },
                        new
                        {
                            ID = 4,
                            Name = "饼干",
                            Url = "Cookie"
                        });
                });

            modelBuilder.Entity("CakeStore.Shared.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("CakeStore.Shared.Model.OrderItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("CakeId")
                        .HasColumnType("int");

                    b.Property<int>("CakeTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId", "CakeId", "CakeTypeId");

                    b.HasIndex("CakeId");

                    b.HasIndex("CakeTypeId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("CakeStore.Shared.Model.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DataCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CakeStore.Shared.Model.Address", b =>
                {
                    b.HasOne("CakeStore.Shared.Model.User", null)
                        .WithOne("Address")
                        .HasForeignKey("CakeStore.Shared.Model.Address", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CakeStore.Shared.Model.Cake", b =>
                {
                    b.HasOne("CakeStore.Shared.Model.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CakeStore.Shared.Model.CakeVariant", b =>
                {
                    b.HasOne("CakeStore.Shared.Model.Cake", "Cake")
                        .WithMany("CakeVariants")
                        .HasForeignKey("CakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CakeStore.Shared.Model.CakeType", "CakeType")
                        .WithMany()
                        .HasForeignKey("CakeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cake");

                    b.Navigation("CakeType");
                });

            modelBuilder.Entity("CakeStore.Shared.Model.OrderItem", b =>
                {
                    b.HasOne("CakeStore.Shared.Model.Cake", "Cake")
                        .WithMany()
                        .HasForeignKey("CakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CakeStore.Shared.Model.CakeType", "CakeType")
                        .WithMany()
                        .HasForeignKey("CakeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CakeStore.Shared.Model.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cake");

                    b.Navigation("CakeType");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("CakeStore.Shared.Model.Cake", b =>
                {
                    b.Navigation("CakeVariants");
                });

            modelBuilder.Entity("CakeStore.Shared.Model.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("CakeStore.Shared.Model.User", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
