﻿// <auto-generated />
using System;
using DemoTU.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionCoursWeb.Migrations
{
    [DbContext(typeof(AnnuaireContext))]
    [Migration("20220903171647_Initialisation")]
    partial class Initialisation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DemoTU.Models.Diplome", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Niveau")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Code");

                    b.ToTable("Diplomes");
                });

            modelBuilder.Entity("DemoTU.Models.Eleve", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CodePostal")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Eleves");
                });

            modelBuilder.Entity("DemoTU.Models.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Debut")
                        .HasColumnType("datetime2");

                    b.Property<string>("DiplomeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("Fin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DiplomeCode");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("ElevePromotion", b =>
                {
                    b.Property<int>("ElevesId")
                        .HasColumnType("int");

                    b.Property<int>("PromotionsId")
                        .HasColumnType("int");

                    b.HasKey("ElevesId", "PromotionsId");

                    b.HasIndex("PromotionsId");

                    b.ToTable("ElevePromotion");
                });

            modelBuilder.Entity("DemoTU.Models.Promotion", b =>
                {
                    b.HasOne("DemoTU.Models.Diplome", "Diplome")
                        .WithMany("Promotions")
                        .HasForeignKey("DiplomeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diplome");
                });

            modelBuilder.Entity("ElevePromotion", b =>
                {
                    b.HasOne("DemoTU.Models.Eleve", null)
                        .WithMany()
                        .HasForeignKey("ElevesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DemoTU.Models.Promotion", null)
                        .WithMany()
                        .HasForeignKey("PromotionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DemoTU.Models.Diplome", b =>
                {
                    b.Navigation("Promotions");
                });
#pragma warning restore 612, 618
        }
    }
}
