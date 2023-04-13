﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechTreeAPI.SqlServe.DataBase;

namespace TechTreeAPI.SqlServe.Migrations
{
    [DbContext(typeof(TechTreeDbContext))]
    [Migration("20210105120755_init3")]
    partial class init3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TechTreeAPI.Model.Main.Build", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BuildName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Cost")
                        .HasColumnType("bigint");

                    b.Property<int>("MaxCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Builds");
                });
#pragma warning restore 612, 618
        }
    }
}
