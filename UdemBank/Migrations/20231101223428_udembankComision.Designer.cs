﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UdemBank;

#nullable disable

namespace UdemBank.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20231101223428_udembankComision")]
    partial class udembankComision
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("UdemBank.CuentaDeAhorro", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("id_propietario")
                        .HasColumnType("INTEGER");

                    b.Property<double>("saldo")
                        .HasColumnType("REAL");

                    b.HasKey("id");

                    b.ToTable("CuentasDeAhorros");
                });

            modelBuilder.Entity("UdemBank.GrupoDeAhorro", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NombreGrupo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("SaldoGrupo")
                        .HasColumnType("REAL");

                    b.Property<int>("id_CreadorGrupo")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("GruposDeAhorros");
                });

            modelBuilder.Entity("UdemBank.Prestamo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("cantidadAPagar")
                        .HasColumnType("REAL");

                    b.Property<double>("cantidadCuota")
                        .HasColumnType("REAL");

                    b.Property<double>("cantidadPrestamo")
                        .HasColumnType("REAL");

                    b.Property<double>("deudaActual")
                        .HasColumnType("REAL");

                    b.Property<DateOnly>("fechaPlazo")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("fechaPrestamo")
                        .HasColumnType("TEXT");

                    b.Property<int>("id_usuarioXGrupoDeAhorro")
                        .HasColumnType("INTEGER");

                    b.Property<double>("interes")
                        .HasColumnType("REAL");

                    b.HasKey("id");

                    b.HasIndex("id_usuarioXGrupoDeAhorro");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("UdemBank.Transacciones", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("CantidadTransaccion")
                        .HasColumnType("REAL");

                    b.Property<string>("TipoTransaccion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("id_cuentaDeAhorro")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("id_cuentaDeAhorro");

                    b.ToTable("TransaccionesCuentaAhorros");
                });

            modelBuilder.Entity("UdemBank.TransaccionesGrupoAhorro", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("CantidadTransaccion")
                        .HasColumnType("REAL");

                    b.Property<string>("TipoTransaccion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("idUsuarioXGrupo")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("idUsuarioXGrupo");

                    b.ToTable("TransaccionesGruposAhorros");
                });

            modelBuilder.Entity("UdemBank.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("clave")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("UdemBank.UsuarioXGrupoAhorro", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PerteneceAlGrupo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("id_GrupoAhorro")
                        .HasColumnType("INTEGER");

                    b.Property<int>("id_ParticipanteGrupo")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("id_GrupoAhorro");

                    b.HasIndex("id_ParticipanteGrupo");

                    b.ToTable("UsuariosXGruposAhorros");
                });

            modelBuilder.Entity("UdemBank.udemBank", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("comision")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("udemBanks");
                });

            modelBuilder.Entity("UdemBank.Prestamo", b =>
                {
                    b.HasOne("UdemBank.UsuarioXGrupoAhorro", "usuarioXGrupoDeAhorro")
                        .WithMany()
                        .HasForeignKey("id_usuarioXGrupoDeAhorro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("usuarioXGrupoDeAhorro");
                });

            modelBuilder.Entity("UdemBank.Transacciones", b =>
                {
                    b.HasOne("UdemBank.CuentaDeAhorro", "CuentaDeAhorro")
                        .WithMany()
                        .HasForeignKey("id_cuentaDeAhorro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CuentaDeAhorro");
                });

            modelBuilder.Entity("UdemBank.TransaccionesGrupoAhorro", b =>
                {
                    b.HasOne("UdemBank.UsuarioXGrupoAhorro", "UsuarioXGrupoAhorro")
                        .WithMany()
                        .HasForeignKey("idUsuarioXGrupo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioXGrupoAhorro");
                });

            modelBuilder.Entity("UdemBank.UsuarioXGrupoAhorro", b =>
                {
                    b.HasOne("UdemBank.GrupoDeAhorro", "GrupoDeAhorro")
                        .WithMany()
                        .HasForeignKey("id_GrupoAhorro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UdemBank.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("id_ParticipanteGrupo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoDeAhorro");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
