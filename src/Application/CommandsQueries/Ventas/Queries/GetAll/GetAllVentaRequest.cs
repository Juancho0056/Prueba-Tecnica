
using Ophelia.Application.Common.Abstracts;
using System;

namespace Application.CommandsQueries.Ventas.Queries.GetAll
{
    public class GetAllVentaRequest : QueryRequest<GetAllVentaResponse>
    {
        public int Id { get; set; }
        public DateTime FechaVenta { get; set; }
        public int ClienteId { get; set; }
        public bool? EstadoRegistro { get; set; }
    }
}
