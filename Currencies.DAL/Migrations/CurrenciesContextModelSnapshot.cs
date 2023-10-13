﻿// <auto-generated />
using System;
using Currencies.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Currencies.DAL.Migrations
{
    [DbContext(typeof(CurrenciesContext))]
    partial class CurrenciesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("Currencies.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Currencies.DAL.Entities.ValCurs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("DateString")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ValCurs");
                });

            modelBuilder.Entity("Currencies.DAL.Entities.Valute", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("CharCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Nominal")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumCode")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ValCursId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.Property<string>("VunitRate")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ValCursId");

                    b.ToTable("Valutes");
                });

            modelBuilder.Entity("Currencies.DAL.Entities.Valute", b =>
                {
                    b.HasOne("Currencies.DAL.Entities.ValCurs", "ValCurs")
                        .WithMany("Valutes")
                        .HasForeignKey("ValCursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ValCurs");
                });

            modelBuilder.Entity("Currencies.DAL.Entities.ValCurs", b =>
                {
                    b.Navigation("Valutes");
                });
#pragma warning restore 612, 618
        }
    }
}