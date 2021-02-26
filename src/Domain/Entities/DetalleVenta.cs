using Ophelia.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ophelia.Domain.Entities
{
    [Table("detalleventas", Schema = "facturacion")]
    public class DetalleVenta: AuditableEntity
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public virtual Venta Venta { get; set; }
        public int ArticuloId { get; set; }
        public virtual Articulo Articulo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Valor { get; set; }
    }
}
