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
    [Migration("20240219150841_migr10")]
    partial class migr10
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

                    b.ToTable("AccessPoints");
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

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Keycards");
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

                    b.HasKey("Id");

                    b.ToTable("Roles");
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

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("UserId");

                    b.ToTable("UsageHistories");
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

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("skyline_odyssey_keycard_management.Models.Keycard", b =>
                {
                    b.HasOne("skyline_odyssey_keycard_management.Models.User", "User")
                        .WithOne("Keycard")
                        .HasForeignKey("skyline_odyssey_keycard_management.Models.Keycard", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("skyline_odyssey_keycard_management.Models.UsageHistory", b =>
                {
                    b.HasOne("skyline_odyssey_keycard_management.Models.Keycard", "Keycard")
                        .WithMany("UsageHistories")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("skyline_odyssey_keycard_management.Models.User", "User")
                        .WithMany("UsageHistories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Keycard");

                    b.Navigation("User");
                });

            modelBuilder.Entity("skyline_odyssey_keycard_management.Models.User", b =>
                {
                    b.HasOne("skyline_odyssey_keycard_management.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("skyline_odyssey_keycard_management.Models.Keycard", b =>
                {
                    b.Navigation("UsageHistories");
                });

            modelBuilder.Entity("skyline_odyssey_keycard_management.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("skyline_odyssey_keycard_management.Models.User", b =>
                {
                    b.Navigation("Keycard")
                        .IsRequired();

                    b.Navigation("UsageHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
