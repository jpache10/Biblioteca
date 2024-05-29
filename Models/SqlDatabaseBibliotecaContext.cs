using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models;

public partial class SqlDatabaseBibliotecaContext : DbContext
{
    public SqlDatabaseBibliotecaContext()
    {
    }

    public SqlDatabaseBibliotecaContext(DbContextOptions<SqlDatabaseBibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autore> Autores { get; set; }

    public virtual DbSet<Ciencia> Ciencias { get; set; }

    public virtual DbSet<Editora> Editoras { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Idioma> Idiomas { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<PrestamoDevolucion> PrestamoDevolucions { get; set; }

    public virtual DbSet<TiposBibliografium> TiposBibliografia { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Biblioteca");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autore>(entity =>
        {
            entity.HasKey(e => e.Identificador).HasName("PK__Autores__F2374EB187A61A20");

            entity.Property(e => e.Identificador).ValueGeneratedNever();
        });

        modelBuilder.Entity<Ciencia>(entity =>
        {
            entity.HasKey(e => e.Identificador).HasName("PK__Ciencias__F2374EB127E7D75D");

            entity.Property(e => e.Identificador).ValueGeneratedNever();
        });

        modelBuilder.Entity<Editora>(entity =>
        {
            entity.HasKey(e => e.Identificador).HasName("PK__Editoras__F2374EB170C37B1E");

            entity.Property(e => e.Identificador).ValueGeneratedNever();
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Identificador).HasName("PK__Empleado__F2374EB1C058497D");

            entity.Property(e => e.Identificador).ValueGeneratedNever();
        });

        modelBuilder.Entity<Idioma>(entity =>
        {
            entity.HasKey(e => e.Identificador).HasName("PK__Idiomas__F2374EB1BFCBD7E5");

            entity.Property(e => e.Identificador).ValueGeneratedNever();
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.Identificador).HasName("PK__Libros__F2374EB1201BE782");

            entity.Property(e => e.Identificador).ValueGeneratedNever();

            entity.HasOne(d => d.AutoresNavigation).WithMany(p => p.Libros).HasConstraintName("FK__Libros__Autores__6754599E");

            entity.HasOne(d => d.CienciaNavigation).WithMany(p => p.Libros).HasConstraintName("FK__Libros__Ciencia__693CA210");

            entity.HasOne(d => d.EditoraNavigation).WithMany(p => p.Libros).HasConstraintName("FK__Libros__Editora__68487DD7");

            entity.HasOne(d => d.IdiomaNavigation).WithMany(p => p.Libros).HasConstraintName("FK__Libros__Idioma__6A30C649");

            entity.HasOne(d => d.TipoBibliografiaNavigation).WithMany(p => p.Libros).HasConstraintName("FK__Libros__TipoBibl__66603565");
        });

        modelBuilder.Entity<PrestamoDevolucion>(entity =>
        {
            entity.HasKey(e => e.NoPrestamo).HasName("PK__Prestamo__E21CCFF3472922B1");

            entity.Property(e => e.NoPrestamo).ValueGeneratedNever();

            entity.HasOne(d => d.EmpleadoNavigation).WithMany(p => p.PrestamoDevolucions).HasConstraintName("FK__PrestamoD__Emple__70DDC3D8");

            entity.HasOne(d => d.LibroNavigation).WithMany(p => p.PrestamoDevolucions).HasConstraintName("FK__PrestamoD__Libro__71D1E811");

            entity.HasOne(d => d.UsuarioNavigation).WithMany(p => p.PrestamoDevolucions).HasConstraintName("FK__PrestamoD__Usuar__72C60C4A");
        });

        modelBuilder.Entity<TiposBibliografium>(entity =>
        {
            entity.HasKey(e => e.Identificador).HasName("PK__TiposBib__F2374EB192DD4C49");

            entity.Property(e => e.Identificador).ValueGeneratedNever();
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Identificador).HasName("PK__Usuarios__F2374EB14AAEC3E4");

            entity.Property(e => e.Identificador).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
