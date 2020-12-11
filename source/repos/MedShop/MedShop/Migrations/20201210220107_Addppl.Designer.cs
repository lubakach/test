﻿// <auto-generated />
using System;
using MedShop;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MedShop.Migrations
{
    [DbContext(typeof(AppDBContent))]
    [Migration("20201210220107_Addppl")]
    partial class Addppl
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MedShop.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("categoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("desc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("MedShop.Models.Medicine", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("available")
                        .HasColumnType("bit");

                    b.Property<int>("categoryID")
                        .HasColumnType("int");

                    b.Property<string>("img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isFavourite")
                        .HasColumnType("bit");

                    b.Property<string>("longDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<string>("shortDesc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("categoryID");

                    b.ToTable("Medicine");
                });

            modelBuilder.Entity("MedShop.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("adress")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(23)
                        .HasColumnType("nvarchar(23)");

                    b.Property<DateTime>("orderTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasMaxLength(33)
                        .HasColumnType("nvarchar(33)");

                    b.HasKey("id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("MedShop.Models.OrderDetail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("MedicineID")
                        .HasColumnType("int");

                    b.Property<int>("orderID")
                        .HasColumnType("int");

                    b.Property<long>("price")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("MedicineID");

                    b.HasIndex("orderID");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("MedShop.Models.ShopCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ShopCartId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("medicineid")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("medicineid");

                    b.ToTable("ShopCartItem");
                });

            modelBuilder.Entity("MedShop.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MedShop.Models.Medicine", b =>
                {
                    b.HasOne("MedShop.Models.Category", "Category")
                        .WithMany("medicines")
                        .HasForeignKey("categoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MedShop.Models.OrderDetail", b =>
                {
                    b.HasOne("MedShop.Models.Medicine", "medicine")
                        .WithMany()
                        .HasForeignKey("MedicineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedShop.Models.Order", "order")
                        .WithMany("orderDetails")
                        .HasForeignKey("orderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("medicine");

                    b.Navigation("order");
                });

            modelBuilder.Entity("MedShop.Models.ShopCartItem", b =>
                {
                    b.HasOne("MedShop.Models.Medicine", "medicine")
                        .WithMany()
                        .HasForeignKey("medicineid");

                    b.Navigation("medicine");
                });

            modelBuilder.Entity("MedShop.Models.Category", b =>
                {
                    b.Navigation("medicines");
                });

            modelBuilder.Entity("MedShop.Models.Order", b =>
                {
                    b.Navigation("orderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
