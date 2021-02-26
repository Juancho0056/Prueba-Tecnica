using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ophelia.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ophelia.Domain.Entities
{
    public class UnidadConfiguration : IEntityTypeConfiguration<Unidad>
    {
        public void Configure(EntityTypeBuilder<Unidad> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Detalle)
               .HasColumnType("varchar(50)")
               .IsRequired();
        }
    }
}
