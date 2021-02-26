using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ophelia.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ophelia.Domain.Entities
{
    [Table("detalleventas", Schema = "facturacion")]
    public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Cantidad)
               .HasColumnType("numeric(28, 8)");
            builder.Property(t => t.Valor)
               .HasColumnType("numeric(28, 8)")
               .IsRequired();
            builder.HasOne(t => t.Venta)
               .WithMany(z => z.DetalleFactura)
               .HasForeignKey(s => s.VentaId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Articulo)
               .WithMany()
               .HasForeignKey(s => s.ArticuloId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
