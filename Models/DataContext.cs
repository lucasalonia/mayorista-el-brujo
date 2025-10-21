using Microsoft.EntityFrameworkCore;

namespace mayorista_el_brujo.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        // DbSet para las entidades manejadas por EF Core: DataContext es una clase que hereda de DbContext, 
        // la cual representa una sesión de trabajo con la base de datos. 
        // Es el puente entre tu aplicación y la base de datos usando Entity Framework Core. - ChatGpt
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
