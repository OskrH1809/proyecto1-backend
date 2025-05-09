using Microsoft.EntityFrameworkCore;
using Proyecto1.Domain.Entities;

namespace Proyecto1.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Autor> Autores => Set<Autor>();
    public DbSet<Libro> Libros => Set<Libro>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Autor>(entity =>
        {
            entity.Property(a => a.NombreCompleto).IsRequired();
            entity.Property(a => a.FechaNacimiento).IsRequired();
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.Property(l => l.Titulo).IsRequired();
            entity.Property(l => l.Anio).IsRequired();
        });
    }
}
