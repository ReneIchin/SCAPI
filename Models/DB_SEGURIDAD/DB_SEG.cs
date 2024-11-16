using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SCAPI.Models.DB_SEGURIDAD;

public partial class DB_SEG : DbContext
{
    public DB_SEG(DbContextOptions<DB_SEG> options)
        : base(options)
    {
    }

    public virtual DbSet<C_ACCIONES> C_ACCIONES { get; set; }

    public virtual DbSet<C_EMPRESAS> C_EMPRESAS { get; set; }

    public virtual DbSet<C_ESTATUS> C_ESTATUS { get; set; }

    public virtual DbSet<C_GRUPO_MODULO> C_GRUPO_MODULO { get; set; }

    public virtual DbSet<C_MODULOS> C_MODULOS { get; set; }

    public virtual DbSet<C_ROLES> C_ROLES { get; set; }

    public virtual DbSet<C_SISTEMAS> C_SISTEMAS { get; set; }

    public virtual DbSet<C_TIPOS_EMPRESAS> C_TIPOS_EMPRESAS { get; set; }

    public virtual DbSet<C_TIPO_CONTRATO> C_TIPO_CONTRATO { get; set; }

    public virtual DbSet<C_TIPO_PAGO> C_TIPO_PAGO { get; set; }

    public virtual DbSet<C_USUARIOS> C_USUARIOS { get; set; }

    public virtual DbSet<M_PAGOS> M_PAGOS { get; set; }

    public virtual DbSet<PERMISOS_MODULOS> PERMISOS_MODULOS { get; set; }

    public virtual DbSet<USUARIO_EMPRESA> USUARIO_EMPRESA { get; set; }

    public virtual DbSet<USUARIO_KEY> USUARIO_KEY { get; set; }

    public virtual DbSet<USUARIO_ROLES> USUARIO_ROLES { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<C_ACCIONES>(entity =>
        {
            entity.Property(e => e.ACCION_ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<C_EMPRESAS>(entity =>
        {
            entity.Property(e => e.EMPRESA_ID).ValueGeneratedNever();

            entity.HasOne(d => d.TIPO_CONTRATO).WithMany(p => p.C_EMPRESAS)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_C_EMPRESAS_C_TIPO_CONTRATO");

            entity.HasOne(d => d.TIPO_EMPRESA).WithMany(p => p.C_EMPRESAS)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_C_EMPRESAS_C_TIPOS_EMPRESAS");

            entity.HasOne(d => d.TIPO_PAGO).WithMany(p => p.C_EMPRESAS)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_C_EMPRESAS_C_TIPO_PAGO");
        });

        modelBuilder.Entity<C_ESTATUS>(entity =>
        {
            entity.Property(e => e.ESTATUS_ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<C_GRUPO_MODULO>(entity =>
        {
            entity.Property(e => e.GRUPO_MODULO_ID).ValueGeneratedNever();

            entity.HasOne(d => d.SISTEMA).WithMany(p => p.C_GRUPO_MODULO)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_C_GRUPO_MODULO_C_SISTEMAS");
        });

        modelBuilder.Entity<C_MODULOS>(entity =>
        {
            entity.Property(e => e.MODULO_ID).ValueGeneratedNever();

            entity.HasOne(d => d.GRUPO_MODULO).WithMany(p => p.C_MODULOS)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_C_MODULOS_C_GRUPO_MODULO");
        });

        modelBuilder.Entity<C_ROLES>(entity =>
        {
            entity.Property(e => e.ROL_ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<C_SISTEMAS>(entity =>
        {
            entity.Property(e => e.SISTEMA_ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<C_TIPOS_EMPRESAS>(entity =>
        {
            entity.Property(e => e.TIPO_EMPRESA_ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<C_TIPO_CONTRATO>(entity =>
        {
            entity.Property(e => e.TIPO_CONTRATO_ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<C_TIPO_PAGO>(entity =>
        {
            entity.Property(e => e.TIPO_PAGO_ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<C_USUARIOS>(entity =>
        {
            entity.Property(e => e.USUARIO_ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<M_PAGOS>(entity =>
        {
            entity.Property(e => e.PAGO_ID).ValueGeneratedNever();

            entity.HasOne(d => d.EMPRESA).WithMany(p => p.M_PAGOS)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_M_PAGOS_C_EMPRESAS");

            entity.HasOne(d => d.ESTATUS).WithMany(p => p.M_PAGOS)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_M_PAGOS_C_ESTATUS");

            entity.HasOne(d => d.TIPO_CONTRATO).WithMany(p => p.M_PAGOS)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_M_PAGOS_C_TIPO_CONTRATO");
        });

        modelBuilder.Entity<PERMISOS_MODULOS>(entity =>
        {
            entity.Property(e => e.PERMISO_MODULO_ID).ValueGeneratedNever();

            entity.HasOne(d => d.ACCION).WithMany(p => p.PERMISOS_MODULOS)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PERMISOS_MODULOS_C_ACCIONES");

            entity.HasOne(d => d.EMPRESA).WithMany(p => p.PERMISOS_MODULOS).HasConstraintName("FK_PERMISOS_MODULOS_C_EMPRESAS");

            entity.HasOne(d => d.MODULO).WithMany(p => p.PERMISOS_MODULOS)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PERMISOS_MODULOS_C_MODULOS");

            entity.HasOne(d => d.ROL).WithMany(p => p.PERMISOS_MODULOS)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PERMISOS_MODULOS_C_ROLES");
        });

        modelBuilder.Entity<USUARIO_EMPRESA>(entity =>
        {
            entity.Property(e => e.USUARIO_EMPRESA_ID).ValueGeneratedNever();

            entity.HasOne(d => d.EMPRESA).WithMany(p => p.USUARIO_EMPRESA)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USUARIO_EMPRESA_C_EMPRESAS");

            entity.HasOne(d => d.USUARIO).WithMany(p => p.USUARIO_EMPRESA)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USUARIO_EMPRESA_C_USUARIOS");
        });

        modelBuilder.Entity<USUARIO_KEY>(entity =>
        {
            entity.Property(e => e.USER_KEY_ID).ValueGeneratedNever();

            entity.HasOne(d => d.USUARIO).WithMany(p => p.USUARIO_KEY)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USUARIO_KEY_C_USUARIOS");
        });

        modelBuilder.Entity<USUARIO_ROLES>(entity =>
        {
            entity.Property(e => e.USUARIO_ROL_ID).ValueGeneratedNever();

            entity.HasOne(d => d.ROL).WithMany(p => p.USUARIO_ROLES)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USUARIO_ROLES_C_ROLES");

            entity.HasOne(d => d.USUARIO).WithMany(p => p.USUARIO_ROLES)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USUARIO_ROLES_C_USUARIOS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
