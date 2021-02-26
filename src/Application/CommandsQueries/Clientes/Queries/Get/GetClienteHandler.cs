using Application.CommandQueries.Clientes;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandsQueries.Clientes.Queries.Get
{
    public class GetClienteHandler : QueryRequestHandler<GetClienteRequest, ClienteDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetClienteHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<ClienteDto> HandleQuery(GetClienteRequest request, CancellationToken cancellationToken)
        {
            var vm = await _context.clientes
                     .AsNoTracking()
                     .Where(e => e.Id == request.Id)
                     .ProjectTo<ClienteDto>(_mapper.ConfigurationProvider)
                     .FirstOrDefaultAsync(cancellationToken);
            return vm;
        }
    }
}
