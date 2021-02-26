
using Ophelia.Application.Common.Abstracts;
using System;

namespace Application.CommandsQueries.Clientes.Queries.GetAll
{
    public class GetAllClienteRequest : QueryRequest<GetAllClienteResponse>
    {
        public int? Id { get; set; }
        public string TipoDocumentoId { get; set; }
        public string NroDocumento { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public bool? EstadoRegistro { get; set; }
    }
}
