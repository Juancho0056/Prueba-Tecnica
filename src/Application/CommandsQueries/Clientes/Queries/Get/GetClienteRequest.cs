using Application.CommandQueries.Clientes;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Application.CommandsQueries.Clientes.Queries.Get
{
    public class GetClienteRequest : QueryRequest<ClienteDto>
    {
        [Required(ErrorMessage=ErrorMessage.IsRequired)]
        public int Id { get; set; }
    }
}
