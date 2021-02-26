using Application.CommandQueries.TipoDocumentos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Interfaces;
using Ophelia.Application.Common.Models;
using Ophelia.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandsQueries.TipoDocumentos.Queries.GetAll
{
    public class GetAllTipoDocumentoHandler : QueryRequestHandler<GetAllTipoDocumentoRequest, GetAllTipoDocumentoResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllTipoDocumentoHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<GetAllTipoDocumentoResponse> HandleQuery(GetAllTipoDocumentoRequest request, CancellationToken cancellationToken)
        {
            IQueryable<TipoDocumento> query = (from v in _context.tipodocumentos
                                        orderby v.Detalle descending
                                        select v);
            if (!string.IsNullOrEmpty(request.Id))
            {
                query = query.Where(v => v.Id.ToString().Contains(request.Id.ToString()));
            }
            if (!string.IsNullOrEmpty(request.Detalle))
            {
                query = query.Where(v => v.Detalle.ToLower().Contains(request.Detalle.ToLower()) );
            }
            if (request.EstadoRegistro != null)
            {
                query = query.Where(v => v.EstadoRegistro.Equals(request.EstadoRegistro));
            }
            if(request.sort != null)                         
                query = request.sort.Length > 0 ? query = query.ApplySorting(request.sort) 
                    : query = query.OrderBy(c => c.Id);
            
            int count = query.Count();

            var pages = ((int)Math.Ceiling((double)count / request.Limit));
            /**var data = await query.AsNoTracking()
                            .Skip((request.Page - 1) * request.Limit)
                            .Take(request.Limit).ProjectTo<TipoDocumentoDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);**/
            var data = await query.AsNoTracking()
                            .ProjectTo<TipoDocumentoDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);
            var vm = new GetAllTipoDocumentoResponse
            {
                Data = data,
                Count = count,
                Pages = pages
            };

            return vm;

        }
    }
}
