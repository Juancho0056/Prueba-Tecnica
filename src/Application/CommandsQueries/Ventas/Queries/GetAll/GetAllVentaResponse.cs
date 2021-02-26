using Application.CommandQueries.Ventas;
using System.Collections.Generic;

namespace Application.CommandsQueries.Ventas.Queries.GetAll
{
    public class GetAllVentaResponse
    {
        public ICollection<VentaDto> Data { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
    }
}
