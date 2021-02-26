using Ophelia.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ophelia.Domain.Entities
{
    [Table("ventas", Schema = "facturacion")]
    public class Venta : AuditableEntity
    {
        public int Id { get; set; }
        public DateTime FechaVenta { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public decimal VlrVenta { get; set; }
        public virtual ICollection<DetalleVenta> DetalleFactura { get; set; }
    }
}
