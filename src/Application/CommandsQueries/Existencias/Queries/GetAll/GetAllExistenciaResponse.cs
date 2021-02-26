using Application.CommandQueries.Existencias;
using System.Collections.Generic;

namespace Application.CommandsQueries.Existencias.Queries.GetAll
{
    public class GetAllExistenciaResponse
    {
        public ICollection<ExistenciaDto> Data { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
    }
}
