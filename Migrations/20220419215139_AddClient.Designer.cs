﻿// <auto-generated />
using System;
using G_Stock_Vente.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace G_Stock_Vente.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220419215139_AddClient")]
    partial class AddClient
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("G_Stock_Vente.Models.Client", b =>
                {
                    b.Property<int>("clientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("codeClt")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("emailClt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nomClt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("paysClt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneClt")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("postalClt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("statutClt")
                        .HasColumnType("bit");

                    b.Property<string>("villeClt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("clientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("G_Stock_Vente.Models.General", b =>
                {
                    b.Property<int>("reference")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("alerteJour")
                        .HasColumnType("int");

                    b.Property<string>("appNom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("devise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dte_creation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("last_modification")
                        .HasColumnType("datetime2");

                    b.HasKey("reference");

                    b.ToTable("General");
                });

            modelBuilder.Entity("G_Stock_Vente.Models.Unite", b =>
                {
                    b.Property<int>("uniteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("codeUnite")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("libelleUnite")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("statutUnite")
                        .HasColumnType("bit");

                    b.Property<DateTime>("updated")
                        .HasColumnType("datetime2");

                    b.HasKey("uniteId");

                    b.ToTable("Unites");
                });
#pragma warning restore 612, 618
        }
    }
}