﻿// <auto-generated />
using System;
using DareAcademy_DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DareAcademyDataAccess.Migrations
{
    [DbContext(typeof(DareAcademyContext))]
    partial class DareAcademyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryCourse", b =>
                {
                    b.Property<int>("LiCourseId")
                        .HasColumnType("int");

                    b.Property<int>("SubCategoriesId")
                        .HasColumnType("int");

                    b.HasKey("LiCourseId", "SubCategoriesId");

                    b.HasIndex("SubCategoriesId");

                    b.ToTable("CategoryCourse");
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Application.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Course_ID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Section_ID")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("Course_ID");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("Section_ID");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IconPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubCategoryID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubCategoryID");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Entity.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FavIconPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("contacts");
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Entity.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Certificate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Descount")
                        .HasColumnType("float");

                    b.Property<string>("Descrption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instructor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("OriginalPrice")
                        .HasColumnType("float");

                    b.Property<string>("Requirement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubCategoriesID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Entity.Course_Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Day")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Section_ID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Section_ID");

                    b.ToTable("course_Schedule");
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Entity.Plan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("plans");
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Entity.Plan_Item", b =>
                {
                    b.Property<int>("Course_ID")
                        .HasColumnType("int");

                    b.Property<int>("Plan_ID")
                        .HasColumnType("int");

                    b.HasKey("Course_ID", "Plan_ID");

                    b.HasIndex("Plan_ID");

                    b.ToTable("plan_Item");
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Entity.Process", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Course_ID")
                        .HasColumnType("int");

                    b.Property<string>("Descrption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Course_ID");

                    b.ToTable("process");
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Entity.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Capacity")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Course_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Course_ID");

                    b.ToTable("sections");
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Entity.Section_Student", b =>
                {
                    b.Property<int>("Section_ID")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("Section_ID", "StudentID");

                    b.HasIndex("StudentID");

                    b.ToTable("section_Student");
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Entity.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Course_ID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("Course_ID");

                    b.ToTable("students");
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Entity.Topics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Course_ID")
                        .HasColumnType("int");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Main")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("SubTopicsID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Course_ID");

                    b.HasIndex("SubTopicsID");

                    b.ToTable("topics");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CategoryCourse", b =>
                {
                    b.HasOne("DareAcademy_DataAccess.Entity.Course", null)
                        .WithMany()
                        .HasForeignKey("LiCourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DareAcademy_DataAccess.Entity.Category", null)
                        .WithMany()
                        .HasForeignKey("SubCategoriesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Application.ApplicationUser", b =>
                {
                    b.HasOne("DareAcademy_DataAccess.Entity.Course", "course")
                        .WithMany("LiApplicationUser")
                        .HasForeignKey("Course_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DareAcademy_DataAccess.Entity.Section", "section")
                        .WithMany("LiApplicationUser")
                        .HasForeignKey("Section_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("section");
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Entity.Category", b =>
                {
                    b.HasOne("DareAcademy_DataAccess.Entity.Category", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Entity.Course_Schedule", b =>
                {
                    b.HasOne("DareAcademy_DataAccess.Entity.Section", "section")
                        .WithMany("LiCourse_Schedule")
                        .HasForeignKey("Section_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("section");
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Entity.Plan_Item", b =>
                {
                    b.HasOne("DareAcademy_DataAccess.Entity.Course", "course")
                        .WithMany("LiPlan_Item")
                        .HasForeignKey("Course_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DareAcademy_DataAccess.Entity.Plan", "plan")
                        .WithMany("LiPlan_Item")
                        .HasForeignKey("Plan_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("plan");
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Entity.Process", b =>
                {
                    b.HasOne("DareAcademy_DataAccess.Entity.Course", "course")
                        .WithMany("LiProcess")
                        .HasForeignKey("Course_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("course");
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Entity.Section", b =>
                {
                    b.HasOne("DareAcademy_DataAccess.Entity.Course", "course")
                        .WithMany("LiSection")
                        .HasForeignKey("Course_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("course");
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Entity.Section_Student", b =>
                {
                    b.HasOne("DareAcademy_DataAccess.Entity.Section", "section")
                        .WithMany("LiSection_Student")
                        .HasForeignKey("Section_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DareAcademy_DataAccess.Entity.Student", "student")
                        .WithMany("LiSection_Student")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("section");

                    b.Navigation("student");
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Entity.Student", b =>
                {
                    b.HasOne("DareAcademy_DataAccess.Entity.Course", "course")
                        .WithMany("LiStudent")
                        .HasForeignKey("Course_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("course");
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Entity.Topics", b =>
                {
                    b.HasOne("DareAcademy_DataAccess.Entity.Course", "course")
                        .WithMany("LiTopics")
                        .HasForeignKey("Course_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DareAcademy_DataAccess.Entity.Topics", "SubTopics")
                        .WithMany()
                        .HasForeignKey("SubTopicsID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("SubTopics");

                    b.Navigation("course");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DareAcademy_DataAccess.Application.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DareAcademy_DataAccess.Application.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DareAcademy_DataAccess.Application.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DareAcademy_DataAccess.Application.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Entity.Course", b =>
                {
                    b.Navigation("LiApplicationUser");

                    b.Navigation("LiPlan_Item");

                    b.Navigation("LiProcess");

                    b.Navigation("LiSection");

                    b.Navigation("LiStudent");

                    b.Navigation("LiTopics");
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Entity.Plan", b =>
                {
                    b.Navigation("LiPlan_Item");
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Entity.Section", b =>
                {
                    b.Navigation("LiApplicationUser");

                    b.Navigation("LiCourse_Schedule");

                    b.Navigation("LiSection_Student");
                });

            modelBuilder.Entity("DareAcademy_DataAccess.Entity.Student", b =>
                {
                    b.Navigation("LiSection_Student");
                });
#pragma warning restore 612, 618
        }
    }
}
