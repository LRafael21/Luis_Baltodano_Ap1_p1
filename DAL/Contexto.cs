using Microsoft.EntityFrameworkCore;
using Parcial.Entidades;

public class Contexto:DbContext
{

    public DbSet<Productos> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=Data\Libros.db");
    }

    
} 