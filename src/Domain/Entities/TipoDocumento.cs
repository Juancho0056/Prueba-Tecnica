using Ophelia.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ophelia.Domain.Entities
{
    [Table("tipodocumentos", Schema = "facturacion")]
    public class TipoDocumento : AuditableEntity
    {
        public string Id { get; set; }
        public string Detalle { get; set; }
    }
}
