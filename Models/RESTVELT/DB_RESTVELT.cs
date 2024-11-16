using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.RESTVELT;

public partial class DB_RESTVELT : DbContext
{
    public DB_RESTVELT(DbContextOptions<DB_RESTVELT> options)
        : base(options)
    {
    }

    public virtual DbSet<BLOQUEO_HABITACION> BLOQUEO_HABITACION { get; set; }

    public virtual DbSet<C_CIUDAD> C_CIUDAD { get; set; }

    public virtual DbSet<C_DOCUMENTO_RESERVACION> C_DOCUMENTO_RESERVACION { get; set; }

    public virtual DbSet<C_EMPRESAS> C_EMPRESAS { get; set; }

    public virtual DbSet<C_ESTADOS> C_ESTADOS { get; set; }

    public virtual DbSet<C_ESTATUS> C_ESTATUS { get; set; }

    public virtual DbSet<C_MOTIVOS_BLOQUEOS> C_MOTIVOS_BLOQUEOS { get; set; }

    public virtual DbSet<C_PAISES> C_PAISES { get; set; }

    public virtual DbSet<C_TIPOS_RESERVAS> C_TIPOS_RESERVAS { get; set; }

    public virtual DbSet<C_TIPO_BLOQUEO> C_TIPO_BLOQUEO { get; set; }

    public virtual DbSet<C_TIPO_HABITACION> C_TIPO_HABITACION { get; set; }

    public virtual DbSet<C_TIPO_PAGO> C_TIPO_PAGO { get; set; }

    public virtual DbSet<GRUPOS_RESERVAS> GRUPOS_RESERVAS { get; set; }

    public virtual DbSet<HABITACIONES> HABITACIONES { get; set; }

    public virtual DbSet<RESERVACION> RESERVACION { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BLOQUEO_HABITACION>(entity =>
        {
            entity.Property(e => e.BLOQUEO_HABITACION_ID).ValueGeneratedNever();

            entity.HasOne(d => d.HABITACION).WithMany(p => p.BLOQUEO_HABITACION)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BLOQUEO_HABITACION_HABITACIONES");

            entity.HasOne(d => d.MOTIVO_BLOQUEO).WithMany(p => p.BLOQUEO_HABITACION)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BLOQUEO_HABITACION_C_MOTIVOS_BLOQUEOS");

            entity.HasOne(d => d.TIPO_BLOQUEO).WithMany(p => p.BLOQUEO_HABITACION)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BLOQUEO_HABITACION_C_TIPO_BLOQUEO");
        });

        modelBuilder.Entity<C_CIUDAD>(entity =>
        {
            entity.Property(e => e.CIUDAD_ID).ValueGeneratedNever();

            entity.HasOne(d => d.ESTADO).WithMany(p => p.C_CIUDAD)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_C_CIUDAD_C_ESTADOS");
        });

        modelBuilder.Entity<C_DOCUMENTO_RESERVACION>(entity =>
        {
            entity.Property(e => e.DOC_RESERVACION_ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<C_EMPRESAS>(entity =>
        {
            entity.Property(e => e.EMPRESA_ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<C_ESTADOS>(entity =>
        {
            entity.Property(e => e.ESTADO_ID).ValueGeneratedNever();

            entity.HasOne(d => d.PAIS).WithMany(p => p.C_ESTADOS)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_C_ESTADOS_C_PAISES");
        });

        modelBuilder.Entity<C_ESTATUS>(entity =>
        {
            entity.HasKey(e => e.ESTATUS_ID).HasName("PK_C_ESTATUS_1");

            entity.Property(e => e.ESTATUS_ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<C_MOTIVOS_BLOQUEOS>(entity =>
        {
            entity.Property(e => e.MOTIVO_BLOQUEO_ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<C_PAISES>(entity =>
        {
            entity.Property(e => e.PAIS_ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<C_TIPOS_RESERVAS>(entity =>
        {
            entity.Property(e => e.TIPO_RESERVA_ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<C_TIPO_BLOQUEO>(entity =>
        {
            entity.Property(e => e.TIPO_BLOQUEO_ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<C_TIPO_HABITACION>(entity =>
        {
            entity.Property(e => e.TIPO_HABITACION_ID).ValueGeneratedNever();
            entity.Property(e => e.STATUS).IsFixedLength();
        });

        modelBuilder.Entity<C_TIPO_PAGO>(entity =>
        {
            entity.Property(e => e.TPO_PAGO_ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<GRUPOS_RESERVAS>(entity =>
        {
            entity.Property(e => e.GRUPO_RESERVA_ID).ValueGeneratedNever();

            entity.HasOne(d => d.ESTATUS).WithMany(p => p.GRUPOS_RESERVAS)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRUPOS_RESERVAS_C_ESTATUS");

            entity.HasOne(d => d.RESERVACION).WithMany(p => p.GRUPOS_RESERVAS)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRUPOS_RESERVAS_RESERVACION");

            entity.HasOne(d => d.TIPO_RESERVA).WithMany(p => p.GRUPOS_RESERVAS)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRUPOS_RESERVAS_C_TIPOS_RESERVAS");
        });

        modelBuilder.Entity<HABITACIONES>(entity =>
        {
            entity.Property(e => e.HABITACION_ID).ValueGeneratedNever();

            entity.HasOne(d => d.EMPRESA).WithMany(p => p.HABITACIONES)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HABITACIONES_C_EMPRESAS");

            entity.HasOne(d => d.ESTATUS).WithMany(p => p.HABITACIONES)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HABITACIONES_C_ESTATUS");

            entity.HasOne(d => d.TIPO_HABITACION).WithMany(p => p.HABITACIONES)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HABITACIONES_C_TIPO_HABITACION");
        });

        modelBuilder.Entity<RESERVACION>(entity =>
        {
            entity.Property(e => e.RESERVACION_ID).ValueGeneratedNever();

            entity.HasOne(d => d.CIUDAD).WithMany(p => p.RESERVACION)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RESERVACION_C_CIUDAD");

            entity.HasOne(d => d.ESTATUS).WithMany(p => p.RESERVACION)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RESERVACION_C_ESTATUS");

            entity.HasOne(d => d.HABITACION).WithMany(p => p.RESERVACION)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RESERVACION_HABITACIONES");

            entity.HasOne(d => d.TIPO_PAGO).WithMany(p => p.RESERVACION)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RESERVACION_C_TIPO_PAGO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
