using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ophelia.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ophelia.Domain.Entities
{
    
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(t => t.PrimerNombre)
               .HasColumnType("varchar(40)")
               .IsRequired();
            builder.Property(t => t.SegundoNombre)
               .HasColumnType("varchar(40)");
            builder.Property(t => t.NroDocumento)
               .HasColumnType("varchar(20)")
               .IsRequired();
            builder.HasOne(t => t.TipoDocumento)
               .WithMany()
               .HasForeignKey(s => s.TipoDocumentoId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
