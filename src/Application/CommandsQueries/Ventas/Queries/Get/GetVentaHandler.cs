using Application.CommandQueries.Ventas;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandsQueries.Ventas.Queries.Get
{
    public class GetVentaHandler : QueryRequestHandler<GetVentaRequest, VentaDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetVentaHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<VentaDto> HandleQuery(GetVentaRequest request, CancellationToken cancellationToken)
        {
            var vm = await _context.ventas
                     .AsNoTracking()
                     .Where(e => e.Id == request.Id)
                     .ProjectTo<VentaDto>(_mapper.ConfigurationProvider)
                     .FirstOrDefaultAsync(cancellationToken);
            return vm;
        }
    }
}
