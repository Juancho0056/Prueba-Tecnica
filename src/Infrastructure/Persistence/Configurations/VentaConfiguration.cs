using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ophelia.Domain.Entities
{
    
    public class VentaConfiguration : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(t => t.VlrVenta)
               .HasColumnType("numeric(28, 8)")
               .IsRequired();
            builder.HasOne(t => t.Cliente)
               .WithMany()
               .HasForeignKey(s => s.ClienteId)
               .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
