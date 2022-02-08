using Microsoft.EntityFrameworkCore;
using Parcial.Entidades;

//NoErrroresPorAhora

namespace Parcial.DAL
{


    public class Contexto : DbContext
    {


        public DbSet<Productos> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Data\Libros.db");
        }



    }
}