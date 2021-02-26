using Application.CommandQueries.Existencias;
using Ophelia.Application.Common.Abstracts;

namespace Application.CommandsQueries.Existencias.Queries.Get
{
    public class GetExistenciaRequest : QueryRequest<ExistenciaDto>
    {
        public int Id { get; set; }
    }
}
