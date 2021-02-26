using Application.CommandQueries.Articulos;
using Ophelia.Application.Common.Abstracts;

namespace Application.CommandsQueries.Articulos.Queries.Get
{
    public class GetArticuloRequest : QueryRequest<ArticuloDto>
    {
        public int Id { get; set; }
    }
}
