using Application.CommandQueries.Unidades;
using Ophelia.Application.Common.Abstracts;

namespace Application.CommandsQueries.Unidades.Queries.Get
{
    public class GetUnidadRequest : QueryRequest<UnidadDto>
    {
        public int Id { get; set; }
    }
}
