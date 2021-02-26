using Application.CommandQueries.Clientes;
using System.Collections.Generic;

namespace Application.CommandsQueries.Clientes.Queries.GetAll
{
    public class GetAllClienteResponse
    {
        public ICollection<ClienteDto> Data { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
    }
}
