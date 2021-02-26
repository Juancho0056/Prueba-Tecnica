using Application.CommandQueries.TipoDocumentos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandsQueries.TipoDocumentos.Queries.Get
{
    public class GetTipoDocumentoHandler : QueryRequestHandler<GetTipoDocumentoRequest, TipoDocumentoDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetTipoDocumentoHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<TipoDocumentoDto> HandleQuery(GetTipoDocumentoRequest request, CancellationToken cancellationToken)
        {
            var vm = await _context.tipodocumentos
                     .AsNoTracking()
                     .Where(e => e.Id == request.Id)
                     .ProjectTo<TipoDocumentoDto>(_mapper.ConfigurationProvider)
                     .FirstOrDefaultAsync(cancellationToken);
            return vm;
        }
    }
}
