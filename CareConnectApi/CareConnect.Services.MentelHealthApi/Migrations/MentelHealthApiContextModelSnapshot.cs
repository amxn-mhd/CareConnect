﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CareConnect.Services.MentelHealthApi.Migrations
{
    [DbContext(typeof(MentelHealthApiContext))]
    partial class MentelHealthApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CareConnect.Services.MentelHealthApi.Models.MoodTracker", b =>
                {
                    b.Property<DateOnly>("DateTimeOfEntry")
                        .HasColumnType("date")
                        .HasColumnName("EntryDate");

                    b.Property<string>("CurrentMood")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("DoctorID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DateTimeOfEntry");

                    b.ToTable("MoodTrackers");
                });
#pragma warning restore 612, 618
        }
    }
}
