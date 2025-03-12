﻿// <auto-generated />
using System;
using COMP2139_PRACTICE.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace COMP2139_PRACTICE.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250312192812_AddProjectTasks")]
    partial class AddProjectTasks
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("COMP2139_PRACTICE.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProjectId"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            Description = "COMP 2139",
                            EndDate = new DateTime(2025, 3, 12, 4, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Assignment 3",
                            StartDate = new DateTime(2025, 3, 12, 4, 0, 0, 0, DateTimeKind.Utc),
                            Status = "Pending"
                        },
                        new
                        {
                            ProjectId = 2,
                            Description = "COMP 2139 - Assignment 4",
                            EndDate = new DateTime(2025, 3, 12, 4, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Assignment 4",
                            StartDate = new DateTime(2025, 3, 12, 4, 0, 0, 0, DateTimeKind.Utc),
                            Status = "Pending"
                        });
                });

            modelBuilder.Entity("COMP2139_PRACTICE.Models.ProjectTask", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TaskId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TaskId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectTasks");
                });

            modelBuilder.Entity("COMP2139_PRACTICE.Models.ProjectTask", b =>
                {
                    b.HasOne("COMP2139_PRACTICE.Models.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("COMP2139_PRACTICE.Models.Project", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
