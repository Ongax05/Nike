using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistency;

public class ApiDbContext : DbContext
{
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CategoriaProducto> CategoriaProductos { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<OrdenProducto> OrdenProductos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

}
