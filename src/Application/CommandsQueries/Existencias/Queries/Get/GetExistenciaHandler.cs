using Application.CommandQueries.Existencias;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandsQueries.Existencias.Queries.Get
{
    public class GetExistenciaHandler : QueryRequestHandler<GetExistenciaRequest, ExistenciaDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetExistenciaHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<ExistenciaDto> HandleQuery(GetExistenciaRequest request, CancellationToken cancellationToken)
        {
            var vm = await _context.existencias
                     .AsNoTracking()
                     .Where(e => e.Id == request.Id)
                     .ProjectTo<ExistenciaDto>(_mapper.ConfigurationProvider)
                     .FirstOrDefaultAsync(cancellationToken);
            return vm;
        }
    }
}
