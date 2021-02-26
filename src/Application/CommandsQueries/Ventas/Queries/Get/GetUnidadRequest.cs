using Application.CommandQueries.Ventas;
using Ophelia.Application.Common.Abstracts;

namespace Application.CommandsQueries.Ventas.Queries.Get
{
    public class GetVentaRequest : QueryRequest<VentaDto>
    {
        public int Id { get; set; }
    }
}
