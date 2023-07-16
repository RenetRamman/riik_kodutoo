﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(WebApplication1Context))]
    partial class WebApplication1ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication1.Models.CompanyModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NrOfAtendees")
                        .HasColumnType("int");

                    b.Property<string>("PayingMethod")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CompanyModel");
                });

            modelBuilder.Entity("WebApplication1.Models.EventCompanyModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CompanyModelID")
                        .HasColumnType("int");

                    b.Property<int>("EventModelID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CompanyModelID");

                    b.HasIndex("EventModelID");

                    b.ToTable("EventCompanyModel");
                });

            modelBuilder.Entity("WebApplication1.Models.EventModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("EventModel");
                });

            modelBuilder.Entity("WebApplication1.Models.EventPersonModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("EventModelID")
                        .HasColumnType("int");

                    b.Property<int>("PersonModelID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EventModelID");

                    b.HasIndex("PersonModelID");

                    b.ToTable("EventPersonModel");
                });

            modelBuilder.Entity("WebApplication1.Models.PersonModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayingMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonalId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("PersonModel");
                });

            modelBuilder.Entity("WebApplication1.Models.EventCompanyModel", b =>
                {
                    b.HasOne("WebApplication1.Models.CompanyModel", null)
                        .WithMany("Events")
                        .HasForeignKey("CompanyModelID");

                    b.HasOne("WebApplication1.Models.EventModel", null)
                        .WithMany("Companies")
                        .HasForeignKey("EventModelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.EventPersonModel", b =>
                {
                    b.HasOne("WebApplication1.Models.EventModel", null)
                        .WithMany("Persons")
                        .HasForeignKey("EventModelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.PersonModel", null)
                        .WithMany("Events")
                        .HasForeignKey("PersonModelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.CompanyModel", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("WebApplication1.Models.EventModel", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("Persons");
                });

            modelBuilder.Entity("WebApplication1.Models.PersonModel", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
