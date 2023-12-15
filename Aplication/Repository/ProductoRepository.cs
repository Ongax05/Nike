using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistency;

namespace Aplication.Repository
{
    public class ProductoRepository(ApiDbContext context)
        : GenericRepository<Producto>(context),
            IProducto
    {
        private readonly ApiDbContext context = context;

        public async Task<IEnumerable<Producto>> GetAbrigos()
        {
            var r = await context
                .Productos
                .Include(p => p.CategoriaProducto)
                .Where(
                    p =>
                        p.CategoriaProducto
                            .NombreCategoria
                            .Equals("Abrigos", StringComparison.OrdinalIgnoreCase)
                )
                .ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Producto>> GetCamisetas()
        {
            var r = await context
                .Productos
                .Include(p => p.CategoriaProducto)
                .Where(
                    p =>
                        p.CategoriaProducto
                            .NombreCategoria
                            .Equals("Camisetas", StringComparison.OrdinalIgnoreCase)
                )
                .ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Producto>> GetPantalones()
        {
            var r = await context
                .Productos
                .Include(p => p.CategoriaProducto)
                .Where(
                    p =>
                        p.CategoriaProducto
                            .NombreCategoria
                            .Equals("Pantalones", StringComparison.OrdinalIgnoreCase)
                )
                .ToListAsync();
            return r;
        }
    }
}
