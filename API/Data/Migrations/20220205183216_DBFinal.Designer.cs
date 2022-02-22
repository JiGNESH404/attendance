﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220205183216_DBFinal")]
    partial class DBFinal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("API.Entity.AppAdmin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("API.Entity.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<int>("studentClassId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("studentClassId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Entity.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("attendDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("attendanceStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("studentClassId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("studentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("studentClassId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("API.Entity.studentClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("className")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("studentClass");
                });

            modelBuilder.Entity("API.Entity.AppUser", b =>
                {
                    b.HasOne("API.Entity.studentClass", "studentClass")
                        .WithMany()
                        .HasForeignKey("studentClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("studentClass");
                });

            modelBuilder.Entity("API.Entity.Attendance", b =>
                {
                    b.HasOne("API.Entity.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entity.studentClass", "studentClass")
                        .WithMany()
                        .HasForeignKey("studentClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("studentClass");
                });
#pragma warning restore 612, 618
        }
    }
}
