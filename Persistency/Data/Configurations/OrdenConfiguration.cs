using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class OrdenConfiguration : IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> builder)
        {
            builder.ToTable("Orden");
            builder.HasOne(p=>p.User).WithMany(p=>p.Ordenes).HasForeignKey(p=>p.UserId);
            builder.Property(p=>p.CantidadProductos).HasColumnName("CantidadProductos").HasColumnType("int").IsRequired();
            builder.Property(p=>p.Total).HasColumnName("Total").HasColumnType("double").IsRequired();
            builder.Property(p=>p.Fecha).HasColumnName("Fecha").HasColumnType("datetime").IsRequired();
        }
    }
}