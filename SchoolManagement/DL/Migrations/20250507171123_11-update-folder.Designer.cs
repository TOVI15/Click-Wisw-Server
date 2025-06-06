﻿// <auto-generated />
using System;
using ClickWise.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClickWise.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250507171123_11-update-folder")]
    partial class _11updatefolder
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ClickWise.Core.Entities.Folders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("S3Key")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("ClickWise.Core.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("PermissionType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("ClickWise.Core.Entities.StudentBasicInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("BuildingNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CountryOfBirth")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("HealthInsurance")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("HebrewDateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Kohen_Levi_Israel")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool?>("RegisterStudent")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("folderKey")
                        .HasColumnType("longtext");

                    b.Property<string>("paymentMethod")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ClickWise.Core.Entities.StudentDetails", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FatherCountryOfOrigin")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FatherOccupation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FatherPhone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MotherCountryOfOrigin")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MotherName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MotherOccupation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MotherPhone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MotherPreviousFamily")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Note")
                        .HasColumnType("longtext");

                    b.Property<string>("PreviousSchoolAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PreviousSchoolCity")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PreviousSchoolEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PreviousSchoolPhone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RoshYeshivaName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RoshYeshivaPhone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("YearsOfStudy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("YeshivaName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("StudentDetails");
                });

            modelBuilder.Entity("ClickWise.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Identity")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpDatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ClickWise.Core.Entities.Folders", b =>
                {
                    b.HasOne("ClickWise.Core.Entities.StudentBasicInfo", "Student")
                        .WithOne("Folders")
                        .HasForeignKey("ClickWise.Core.Entities.Folders", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ClickWise.Core.Entities.Permission", b =>
                {
                    b.HasOne("ClickWise.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ClickWise.Core.Entities.StudentDetails", b =>
                {
                    b.HasOne("ClickWise.Core.Entities.StudentBasicInfo", "BasicInfo")
                        .WithOne("AdditionalInfo")
                        .HasForeignKey("ClickWise.Core.Entities.StudentDetails", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BasicInfo");
                });

            modelBuilder.Entity("ClickWise.Core.Entities.StudentBasicInfo", b =>
                {
                    b.Navigation("AdditionalInfo")
                        .IsRequired();

                    b.Navigation("Folders")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
