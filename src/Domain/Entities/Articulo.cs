using Ophelia.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ophelia.Domain.Entities
{
    [Table("articulos", Schema = "facturacion")]
    public class Articulo : AuditableEntity
    {
        public int Id { get; set; }
        public string Detalle { get; set; }
        public int UnidadId { get; set; }
        public virtual Unidad Unidad { get; set; }
        public decimal Precio { get; set; }
    }
}
