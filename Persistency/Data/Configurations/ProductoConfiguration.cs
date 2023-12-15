using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Producto");
            builder.HasOne(p=>p.CategoriaProducto).WithMany(p=>p.Productos).HasForeignKey(p=>p.CategoriaProductoId);
            builder.Property(p=>p.NombreProducto).HasColumnName("NombreProducto").HasMaxLength(100).IsRequired();
            builder.Property(p=>p.Imagen).HasColumnName("Imagen").HasColumnType("longblob").IsRequired();
            builder.Property(p=>p.Precio).HasColumnName("Precio").HasColumnType("double").IsRequired();
            builder.Property(p=>p.Stock).HasColumnName("Stock").HasColumnType("int").IsRequired();
        }
    }
}