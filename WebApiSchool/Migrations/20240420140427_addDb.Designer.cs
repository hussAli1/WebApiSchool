﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiSchool.DataAccess;

#nullable disable

namespace WebApiSchool.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240420140427_addDb")]
    partial class addDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApiSchool.DataAccess.Models.Course", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("GUID");

                    b.ToTable("Courses", (string)null);

                    b.HasData(
                        new
                        {
                            GUID = new Guid("67d98a32-ed8c-4888-9d7a-554e2a85a2b2"),
                            CourseName = "HCi",
                            Price = 100m
                        });
                });

            modelBuilder.Entity("WebApiSchool.DataAccess.Models.GroupPermission", b =>
                {
                    b.Property<int>("PermissionGroupId")
                        .HasColumnType("int");

                    b.Property<string>("PermissionName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("PermissionGroupId", "PermissionName");

                    b.ToTable("GroupPermissions");

                    b.HasData(
                        new
                        {
                            PermissionGroupId = 1,
                            PermissionName = "GetCourse",
                            Id = 1
                        },
                        new
                        {
                            PermissionGroupId = 2,
                            PermissionName = "GetCourseById",
                            Id = 2
                        });
                });

            modelBuilder.Entity("WebApiSchool.DataAccess.Models.PermissionGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PermissionGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("WebApiSchool.DataAccess.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PermissionGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PermissionGroupId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "11",
                            PermissionGroupId = 1,
                            Username = "11"
                        },
                        new
                        {
                            Id = 2,
                            Password = "22",
                            PermissionGroupId = 2,
                            Username = "22"
                        });
                });

            modelBuilder.Entity("WebApiSchool.DataAccess.Models.GroupPermission", b =>
                {
                    b.HasOne("WebApiSchool.DataAccess.Models.PermissionGroup", "PermissionGroup")
                        .WithMany("GroupPermissions")
                        .HasForeignKey("PermissionGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PermissionGroup");
                });

            modelBuilder.Entity("WebApiSchool.DataAccess.Models.User", b =>
                {
                    b.HasOne("WebApiSchool.DataAccess.Models.PermissionGroup", "PermissionGroup")
                        .WithMany("Users")
                        .HasForeignKey("PermissionGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PermissionGroup");
                });

            modelBuilder.Entity("WebApiSchool.DataAccess.Models.PermissionGroup", b =>
                {
                    b.Navigation("GroupPermissions");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}