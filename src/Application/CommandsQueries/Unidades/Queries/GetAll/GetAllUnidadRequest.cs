
using Ophelia.Application.Common.Abstracts;

namespace Application.CommandsQueries.Unidades.Queries.GetAll
{
    public class GetAllUnidadRequest : QueryRequest<GetAllUnidadResponse>
    {
        public int Id { get; set; }
        public string Detalle { get; set; }
        public bool? EstadoRegistro { get; set; }
    }
}
