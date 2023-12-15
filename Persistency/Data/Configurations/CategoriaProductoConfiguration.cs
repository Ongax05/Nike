using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class CategoriaProductoConfiguration : IEntityTypeConfiguration<CategoriaProducto>
    {
        public void Configure(EntityTypeBuilder<CategoriaProducto> builder)
        {
            builder.ToTable("CategoriaProducto");
            builder.Property(p=>p.NombreCategoria).HasColumnName("NombreCategoria").HasMaxLength(100).IsRequired();

        }
    }
}