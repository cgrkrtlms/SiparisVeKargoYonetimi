﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SiparisVeKargoYonetimi.DATA.DataContext;

#nullable disable

namespace SiparisVeKargoYonetimi.DATA.Migrations
{
    [DbContext(typeof(ProjectContext))]
    partial class ProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SiparisVeKargoYonetimi.Core.Models.ArasCargo", b =>
                {
                    b.Property<string>("ArasCargoNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EstimatedDeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ReceiverName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ArasCargoNo");

                    b.ToTable("ArasCargos");
                });

            modelBuilder.Entity("SiparisVeKargoYonetimi.Core.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SiparisVeKargoYonetimi.Core.Models.Clothing", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ArasCargoNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ArasCargoNo")
                        .IsUnique();

                    b.ToTable("Clothings");
                });

            modelBuilder.Entity("SiparisVeKargoYonetimi.Core.Models.Food", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("YurticiCargoNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("YurticiCargoNo")
                        .IsUnique();

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("SiparisVeKargoYonetimi.Core.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool>("Confirmation")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SiparisVeKargoYonetimi.Core.Models.YurticiCargo", b =>
                {
                    b.Property<string>("YurticiCargoNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EstimatedDeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ReceiverName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("YurticiCargoNo");

                    b.ToTable("YurticiCargos");
                });

            modelBuilder.Entity("SiparisVeKargoYonetimi.Core.Models.Clothing", b =>
                {
                    b.HasOne("SiparisVeKargoYonetimi.Core.Models.ArasCargo", "ArasCargo")
                        .WithOne("Clothing")
                        .HasForeignKey("SiparisVeKargoYonetimi.Core.Models.Clothing", "ArasCargoNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArasCargo");
                });

            modelBuilder.Entity("SiparisVeKargoYonetimi.Core.Models.Food", b =>
                {
                    b.HasOne("SiparisVeKargoYonetimi.Core.Models.YurticiCargo", "YurticiCargo")
                        .WithOne("Food")
                        .HasForeignKey("SiparisVeKargoYonetimi.Core.Models.Food", "YurticiCargoNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("YurticiCargo");
                });

            modelBuilder.Entity("SiparisVeKargoYonetimi.Core.Models.ArasCargo", b =>
                {
                    b.Navigation("Clothing")
                        .IsRequired();
                });

            modelBuilder.Entity("SiparisVeKargoYonetimi.Core.Models.YurticiCargo", b =>
                {
                    b.Navigation("Food")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
