using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class OrdenProductoConfiguration : IEntityTypeConfiguration<OrdenProducto>
    {
        public void Configure(EntityTypeBuilder<OrdenProducto> builder)
        {
            builder.ToTable("OrdenProducto");
            builder.HasKey(op=>new {op.ProductoId,op.OrdenId});
            builder.Property(p=>p.Cantidad).HasColumnName("Cantidad").HasColumnType("int").IsRequired();
        }
    }
}