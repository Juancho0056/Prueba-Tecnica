﻿using Application.CommandQueries.Articulos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandsQueries.Articulos.Queries.Get
{
    public class GetArticuloHandler : QueryRequestHandler<GetArticuloRequest, ArticuloDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetArticuloHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<ArticuloDto> HandleQuery(GetArticuloRequest request, CancellationToken cancellationToken)
        {
            var vm = await _context.articulos
                     .AsNoTracking()
                     .Where(e => e.Id == request.Id)
                     .ProjectTo<ArticuloDto>(_mapper.ConfigurationProvider)
                     .FirstOrDefaultAsync(cancellationToken);
            return vm;
        }
    }
}
