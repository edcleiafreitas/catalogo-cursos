using CatalogoCursos.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoCursos.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Curso> Cursos => Set<Curso>();
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Modulo> Modulos => Set<Modulo>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Categoria>().HasData(SeedData.Categorias);
        b.Entity<Curso>().HasData(SeedData.Cursos);
        b.Entity<Modulo>().HasData(SeedData.Modulos);
    }
}
