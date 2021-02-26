using Ophelia.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ophelia.Domain.Entities
{
    [Table("clientes", Schema = "facturacion")]
    public class Cliente : AuditableEntity
    {
        public int Id { get; set; }
        public string TipoDocumentoId { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }
}
