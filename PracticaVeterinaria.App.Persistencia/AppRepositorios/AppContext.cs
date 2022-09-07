using Microsoft.EntityFrameworkCore;
using PracticaVeterinaria.App.Dominio;

namespace PracticaVeterinaria.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Propietario> propietarios { get; set; }
        public DbSet<Veterinario> veterinarios { get; set; }
        public DbSet<Mascota> mascotas { get; set; }
        public DbSet<Visita> visitas { get; set; }

        

        // implementar todas las clases



        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PracticaVeterinaria.Data");
            }
        }

    }
}