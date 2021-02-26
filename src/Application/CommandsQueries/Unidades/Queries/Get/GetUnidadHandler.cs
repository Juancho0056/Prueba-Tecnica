using Application.CommandQueries.Unidades;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandsQueries.Unidades.Queries.Get
{
    public class GetUnidadHandler : QueryRequestHandler<GetUnidadRequest, UnidadDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetUnidadHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<UnidadDto> HandleQuery(GetUnidadRequest request, CancellationToken cancellationToken)
        {
            var vm = await _context.unidades
                     .AsNoTracking()
                     .Where(e => e.Id == request.Id)
                     .ProjectTo<UnidadDto>(_mapper.ConfigurationProvider)
                     .FirstOrDefaultAsync(cancellationToken);
            return vm;
        }
    }
}
