﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using skyline_odyssey_keycard_management;

#nullable disable

namespace skyline_odyssey_keycard_management.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccessPoint", (string)null);
                });

            modelBuilder.Entity("skyline_odyssey_keycard_management.Models.Keycard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAssigned")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Keycard", (string)null);
                });

            modelBuilder.Entity("skyline_odyssey_keycard_management.Models.KeycardRequests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("KeycardRequests", (string)null);
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

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("skyline_odyssey_keycard_management.Models.UsageHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessPointId")
                        .HasColumnType("int");

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<string>("InOut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccessPointId");

                    b.HasIndex("CardId");

                    b.HasIndex("UserId");

                    b.ToTable("UsageHistory", (string)null);
                });

            modelBuilder.Entity("skyline_odyssey_keycard_management.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsInRoom")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("bit");

                    b.Property<int>("KeycardId")
                        .HasColumnType("int");

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

                    b.HasIndex("KeycardId");

                    b.HasIndex("RoleId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("skyline_odyssey_keycard_management.Models.KeycardRequests", b =>
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
                    b.HasOne("skyline_odyssey_keycard_management.Models.AccessPoint", "AccessPoint")
                        .WithMany("UsageHistories")
                        .HasForeignKey("AccessPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("skyline_odyssey_keycard_management.Models.Keycard", "Keycard")
                        .WithMany("UsageHistories")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("skyline_odyssey_keycard_management.Models.User", null)
                        .WithMany("UsageHistories")
                        .HasForeignKey("UserId");

                    b.Navigation("AccessPoint");

                    b.Navigation("Keycard");
                });

            modelBuilder.Entity("skyline_odyssey_keycard_management.Models.User", b =>
                {
                    b.HasOne("skyline_odyssey_keycard_management.Models.Keycard", "Keycard")
                        .WithMany()
                        .HasForeignKey("KeycardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("skyline_odyssey_keycard_management.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Keycard");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("skyline_odyssey_keycard_management.Models.AccessPoint", b =>
                {
                    b.Navigation("UsageHistories");
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
                    b.Navigation("UsageHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
