using Microsoft.EntityFrameworkCore;

namespace EjercicioTaller.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        { }
        
        //protected override void OnModelCreating(ModelBuilder modelBuilder){}

        public DbSet<Vehiculo> Vehiculo { get; set; }
        public DbSet<Automovil> Automovil { get; set; }
        public DbSet<Moto> Moto { get; set; }
        public DbSet<Desperfecto> Desperfecto { get; set; }
        public DbSet<Repuesto> Repuesto { get; set; }
    }
}
