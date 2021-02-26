
using Ophelia.Application.Common.Abstracts;

namespace Application.CommandsQueries.Existencias.Queries.GetAll
{
    public class GetAllExistenciaRequest : QueryRequest<GetAllExistenciaResponse>
    {
        public int Id { get; set; }
        public string Detalle { get; set; }
        public int ArticuloId { get; set; }
        public bool? EstadoRegistro { get; set; }
    }
}
