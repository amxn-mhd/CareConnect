﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CareConnect.Services.SafetyApi.Migrations
{
    [DbContext(typeof(SafetyApiContext))]
    [Migration("20241113091727_Safety_FirstUpdate")]
    partial class Safety_FirstUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CareConnect.Services.SafetyApi.Models.ReportIncident", b =>
                {
                    b.Property<DateOnly>("DateTimeOfEntry")
                        .HasColumnType("date")
                        .HasColumnName("EntryDate");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<TimeOnly>("Time")
                        .HasColumnType("time");

                    b.Property<string>("TypeOfAccident")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DateTimeOfEntry");

                    b.ToTable("ReportIncident");
                });
#pragma warning restore 612, 618
        }
    }
}
