﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using skyline_odyssey_keycard_management;

#nullable disable

namespace skyline_odyssey_keycard_management.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240219145505_migr8")]
    partial class migr8
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("skyline_odyssey_keycard_management.Models.AccessPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessLevel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AccessPoint", (string)null);
                });

            modelBuilder.Entity("skyline_odyssey_keycard_management.Models.Keycard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Keycard", (string)null);
                });

            modelBuilder.Entity("skyline_odyssey_keycard_management.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("skyline_odyssey_keycard_management.Models.UsageHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.ToTable("UsageHistory", (string)null);
                });

            modelBuilder.Entity("skyline_odyssey_keycard_management.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UsageHistoryId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("CardId")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.HasIndex("UsageHistoryId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("skyline_odyssey_keycard_management.Models.Keycard", b =>
                {
                    b.HasOne("skyline_odyssey_keycard_management.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("skyline_odyssey_keycard_management.Models.Role", b =>
                {
                    b.HasOne("skyline_odyssey_keycard_management.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("skyline_odyssey_keycard_management.Models.UsageHistory", b =>
                {
                    b.HasOne("skyline_odyssey_keycard_management.Models.Keycard", "Keycard")
                        .WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Keycard");
                });

            modelBuilder.Entity("skyline_odyssey_keycard_management.Models.User", b =>
                {
                    b.HasOne("skyline_odyssey_keycard_management.Models.Keycard", "Keycard")
                        .WithOne()
                        .HasForeignKey("skyline_odyssey_keycard_management.Models.User", "CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("skyline_odyssey_keycard_management.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("skyline_odyssey_keycard_management.Models.UsageHistory", "UsageHistory")
                        .WithMany()
                        .HasForeignKey("UsageHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Keycard");

                    b.Navigation("Role");

                    b.Navigation("UsageHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
