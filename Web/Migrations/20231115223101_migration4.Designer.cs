﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web.Repos;

#nullable disable

namespace Web.Migrations
{
    [DbContext(typeof(BibliotecaUTNContext))]
    [Migration("20231115223101_migration4")]
    partial class migration4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Web.Models.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nacionalidad")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Autor");
                });

            modelBuilder.Entity("Web.Models.Libro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AutorRefId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaPublicacion")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Genero")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImagenPortada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AutorRefId");

                    b.ToTable("Libro");
                });

            modelBuilder.Entity("Web.Models.Prestamo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FechaDevolucionEsperada")
                        .IsRequired()
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime?>("FechaPrestamo")
                        .IsRequired()
                        .HasColumnType("smalldatetime");

                    b.Property<int?>("LibroRefId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioRefId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LibroRefId");

                    b.HasIndex("UsuarioRefId");

                    b.ToTable("Prestamo");
                });

            modelBuilder.Entity("Web.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CorreoElectronico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Web.Models.Libro", b =>
                {
                    b.HasOne("Web.Models.Autor", "Autor")
                        .WithMany()
                        .HasForeignKey("AutorRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("Web.Models.Prestamo", b =>
                {
                    b.HasOne("Web.Models.Libro", "Libro")
                        .WithMany()
                        .HasForeignKey("LibroRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Libro");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
