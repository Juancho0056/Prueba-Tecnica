
using Ophelia.Application.Common.Abstracts;

namespace Application.CommandsQueries.TipoDocumentos.Queries.GetAll
{
    public class GetAllTipoDocumentoRequest : QueryRequest<GetAllTipoDocumentoResponse>
    {
        public string Id { get; set; }
        public string Detalle { get; set; }
        public bool? EstadoRegistro { get; set; }
    }
}
