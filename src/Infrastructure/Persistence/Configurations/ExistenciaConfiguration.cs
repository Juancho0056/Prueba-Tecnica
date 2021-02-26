using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ophelia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ophelia.Infrastructure.Persistence.Configurations
{
    public class ExistenciaConfiguration : IEntityTypeConfiguration<Existencia>
    {
        public void Configure(EntityTypeBuilder<Existencia> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(t => t.ExistenciaMinima)
               .HasColumnType("numeric(28, 8)")
               .IsRequired();
            builder.Property(t => t.ExistenciaMaxima)
               .HasColumnType("numeric(28, 8)")
               .IsRequired();
            builder.Property(t => t.CantDisponible)
               .HasColumnType("numeric(28, 8)")
               .IsRequired();
            builder.HasOne(t => t.Articulo)
               .WithMany()
               .HasForeignKey(s => s.ArticuloId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
