
using Ophelia.Application.Common.Abstracts;

namespace Application.CommandsQueries.Articulos.Queries.GetAll
{
    public class GetAllArticuloRequest : QueryRequest<GetAllArticuloResponse>
    {
        public int? Id { get; set; }
        public string Detalle { get; set; }
        public int? UnidadId { get; set; }
        public bool? EstadoRegistro { get; set; }
    }
}
