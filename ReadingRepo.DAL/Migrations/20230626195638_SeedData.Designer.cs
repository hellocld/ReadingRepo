﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReadingRepo.DAL.Entities;

#nullable disable

namespace ReadingRepo.DAL.Migrations
{
    [DbContext(typeof(ReadingRepoContext))]
    [Migration("20230626195638_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("ReadingRepo.DAL.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3ee68521-9568-42ed-8c1b-278556e5710c"),
                            FirstName = "Groucho",
                            LastName = "Marx"
                        },
                        new
                        {
                            Id = new Guid("d07b902d-f019-4763-b3e6-a9339dd47e82"),
                            FirstName = "Harpo",
                            LastName = "Marx"
                        });
                });

            modelBuilder.Entity("ReadingRepo.DAL.Entities.AuthorGroup", b =>
                {
                    b.Property<Guid>("GroupId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("TEXT");

                    b.HasKey("GroupId", "AuthorId");

                    b.ToTable("AuthorGroups");

                    b.HasData(
                        new
                        {
                            GroupId = new Guid("ffc04136-7407-4295-bc67-02174f07bfc5"),
                            AuthorId = new Guid("3ee68521-9568-42ed-8c1b-278556e5710c")
                        },
                        new
                        {
                            GroupId = new Guid("ffc04136-7407-4295-bc67-02174f07bfc5"),
                            AuthorId = new Guid("d07b902d-f019-4763-b3e6-a9339dd47e82")
                        });
                });

            modelBuilder.Entity("ReadingRepo.DAL.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AuthorGroupId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CoverImageUri")
                        .HasColumnType("TEXT");

                    b.Property<string>("Isbn")
                        .HasColumnType("TEXT");

                    b.Property<string>("OpenLibraryId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Pages")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("871704e5-a8aa-43be-a449-68221ff5d9a6"),
                            AuthorGroupId = new Guid("ffc04136-7407-4295-bc67-02174f07bfc5"),
                            Pages = 0,
                            PublishDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Hail Freedonia"
                        });
                });

            modelBuilder.Entity("ReadingRepo.DAL.Entities.ReadingLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BookId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ReadingLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
