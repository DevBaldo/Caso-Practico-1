using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities;

public partial class PeliculasContext : DbContext
{
    public PeliculasContext()
    {
    }

    public PeliculasContext(DbContextOptions<PeliculasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Parametro> Parametros { get; set; }

    public virtual DbSet<Programa> Programas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Parametro>(entity =>
        {
            entity.Property(e => e.Descripcion).HasMaxLength(50);
        });

        modelBuilder.Entity<Programa>(entity =>
        {
            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.CategoriaNavigation).WithMany(p => p.ProgramaCategoriaNavigations)
                .HasForeignKey(d => d.Categoria)
                .HasConstraintName("FK_Parametros_categorias");

            entity.HasOne(d => d.TipoNavigation).WithMany(p => p.ProgramaTipoNavigations)
                .HasForeignKey(d => d.Tipo)
                .HasConstraintName("FK__Parametros_tipos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
