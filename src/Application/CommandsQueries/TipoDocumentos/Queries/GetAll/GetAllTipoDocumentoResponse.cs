using Application.CommandQueries.TipoDocumentos;
using System.Collections.Generic;

namespace Application.CommandsQueries.TipoDocumentos.Queries.GetAll
{
    public class GetAllTipoDocumentoResponse
    {
        public ICollection<TipoDocumentoDto> Data { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
    }
}
