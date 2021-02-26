using Ophelia.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ophelia.Domain.Entities
{
    [Table("existencias", Schema = "facturacion")]
    public class Existencia : AuditableEntity
    {
        public int Id { get; set; }
        public Articulo Articulo { get; set; }
        public int ArticuloId { get; set; }
        public decimal ExistenciaMinima { get; set; }
        public decimal ExistenciaMaxima { get; set; }
        public decimal CantDisponible { get; set; }
    }
}
