﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using la_mia_pizzeria_crud_mvc.Database;

#nullable disable

namespace lamiapizzeriacrudmvc.Migrations
{
    [DbContext(typeof(PizzeriaContext))]
    [Migration("20230119150446_AggiunteCategorie")]
    partial class AggiunteCategorie
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("la_mia_pizzeria_crud_mvc.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("la_mia_pizzeria_crud_mvc.Models.Pizze", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Immagine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pizza")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<double>("Prezzo")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Pizza");
                });

            modelBuilder.Entity("la_mia_pizzeria_crud_mvc.Models.Pizze", b =>
                {
                    b.HasOne("la_mia_pizzeria_crud_mvc.Models.Categoria", null)
                        .WithMany("Pizza")
                        .HasForeignKey("CategoriaId");
                });

            modelBuilder.Entity("la_mia_pizzeria_crud_mvc.Models.Categoria", b =>
                {
                    b.Navigation("Pizza");
                });
#pragma warning restore 612, 618
        }
    }
}