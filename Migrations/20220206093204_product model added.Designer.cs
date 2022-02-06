﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop_API.Data;

#nullable disable

namespace OnlineShop_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220206093204_product model added")]
    partial class productmodeladded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OnlineShop_API.Models.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("productD");
                });
#pragma warning restore 612, 618
        }
    }
}
