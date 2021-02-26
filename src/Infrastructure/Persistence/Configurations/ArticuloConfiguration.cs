using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ophelia.Domain.Entities
{
    
    public class ArticuloConfiguration : IEntityTypeConfiguration<Articulo>
    {
        public void Configure(EntityTypeBuilder<Articulo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Detalle)
               .HasColumnType("varchar(50)")
               .IsRequired();
            builder.Property(t => t.Precio)
               .HasColumnType("numeric(28, 8)")
               .IsRequired();
            builder.HasOne(t => t.Unidad)
               .WithMany()
               .HasForeignKey(s => s.UnidadId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
