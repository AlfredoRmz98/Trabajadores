using Microsoft.EntityFrameworkCore;
using WebAppTrabajadores.Entidades;

namespace WebAppTrabajadores
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {   
        }
        public DbSet<Trabajador> Trabajadors { get; set; }

        public DbSet<Trabajador> trabajadors { get; set; }
        public DbSet<Puesto> puestos { get; set; }
    }
}
