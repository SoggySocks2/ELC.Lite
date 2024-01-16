﻿// <auto-generated />
using System;
using ELC.Lite.CoreApp.Infrastucture;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ELC.Lite.CoreApp.Infrastucture.Migrations.CoreDb
{
    [DbContext(typeof(CoreDbContext))]
    partial class CoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ELC.Lite.Domain.Leads.Lead", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("Budget")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Leads");
                });

            modelBuilder.Entity("ELC.Lite.Domain.Leads.Lead", b =>
                {
                    b.OwnsOne("ELC.Lite.Domain.Customers.Customer", "Customer", b1 =>
                        {
                            b1.Property<int>("LeadId")
                                .HasColumnType("int");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Address");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Email");

                            b1.Property<string>("Forenames")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Forenames");

                            b1.Property<string>("Postcode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Postcode");

                            b1.Property<string>("Surname")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Surname");

                            b1.Property<string>("TelNo")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("TelNo");

                            b1.HasKey("LeadId");

                            b1.ToTable("Leads");

                            b1.WithOwner()
                                .HasForeignKey("LeadId");
                        });

                    b.OwnsOne("ELC.Lite.Domain.Vehicles.CurrentVehicle", "CurrentVehicle", b1 =>
                        {
                            b1.Property<int>("LeadId")
                                .HasColumnType("int");

                            b1.Property<string>("Make")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("CurrentVehicleMake");

                            b1.Property<string>("Model")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("CurrentVehicleModel");

                            b1.Property<int?>("Year")
                                .HasColumnType("int")
                                .HasColumnName("CurrentVehicleYear");

                            b1.HasKey("LeadId");

                            b1.ToTable("Leads");

                            b1.WithOwner()
                                .HasForeignKey("LeadId");
                        });

                    b.OwnsOne("ELC.Lite.Domain.Vehicles.InterestedInVehicle", "InterestedInVehicle", b1 =>
                        {
                            b1.Property<int>("LeadId")
                                .HasColumnType("int");

                            b1.Property<string>("Make")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("InterestedInVehicleMake");

                            b1.Property<string>("Model")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("InterestedInVehicleModel");

                            b1.HasKey("LeadId");

                            b1.ToTable("Leads");

                            b1.WithOwner()
                                .HasForeignKey("LeadId");
                        });

                    b.Navigation("CurrentVehicle")
                        .IsRequired();

                    b.Navigation("Customer")
                        .IsRequired();

                    b.Navigation("InterestedInVehicle")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}