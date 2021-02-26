using Ophelia.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ophelia.Domain.Entities
{
    [Table("unidades", Schema = "facturacion")]
    public class Unidad : AuditableEntity
    {
        public  int Id { get; set; }
        public string Detalle { get; set; }
    }
}
