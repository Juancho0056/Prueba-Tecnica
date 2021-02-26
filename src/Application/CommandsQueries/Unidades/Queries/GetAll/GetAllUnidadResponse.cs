using Application.CommandQueries.Unidades;
using System.Collections.Generic;

namespace Application.CommandsQueries.Unidades.Queries.GetAll
{
    public class GetAllUnidadResponse
    {
        public ICollection<UnidadDto> Data { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
    }
}
