using Microsoft.EntityFrameworkCore;
using TiendaApp.Models;
namespace TiendaApp.Data
{
    public class TiendaContext(DbContextOptions<TiendaContext> options) : DbContext(options)
    {
        public DbSet<Marca> Marcas => Set<Marca>(); //Tipo genérico (POO avanzado)
        public DbSet<Producto> Productos => Set<Producto>(); //Tipo genérico (POO avanzado)
    }
}
