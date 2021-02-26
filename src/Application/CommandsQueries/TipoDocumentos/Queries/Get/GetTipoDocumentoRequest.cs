using Application.CommandQueries.TipoDocumentos;
using Ophelia.Application.Common.Abstracts;

namespace Application.CommandsQueries.TipoDocumentos.Queries.Get
{
    public class GetTipoDocumentoRequest : QueryRequest<TipoDocumentoDto>
    {
        public string Id { get; set; }
    }
}
