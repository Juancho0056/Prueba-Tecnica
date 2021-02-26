using Application.CommandQueries.Articulos;
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

namespace Application.CommandsQueries.Articulos.Queries.GetAll
{
    public class GetAllArticuloHandler : QueryRequestHandler<GetAllArticuloRequest, GetAllArticuloResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllArticuloHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<GetAllArticuloResponse> HandleQuery(GetAllArticuloRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Existencia> query = (from v in _context.articulos 
                                          join z in _context.existencias on v.Id equals z.ArticuloId 
                                          orderby v.Detalle descending
                                          select z);
            if (request.Id != null && request.Id > 0)
            {
                query = query.Where(v => v.Articulo.Id.ToString().Contains(request.Id.ToString()));
            }
            if (request.UnidadId != null && request.UnidadId > 0)
            {
                query = query.Where(v => v.Articulo.UnidadId.ToString().Contains(request.UnidadId.ToString()));
            }
            if (!string.IsNullOrEmpty(request.Detalle))
            {
                query = query.Where(v => v.Articulo.Detalle.ToLower().Contains(request.Detalle.ToLower()) );
            }
            if (request.EstadoRegistro != null)
            {
                query = query.Where(v => v.Articulo.EstadoRegistro.Equals(request.EstadoRegistro));
            }
            if(request.sort != null)                         
                query = request.sort.Length > 0 ? query = query.ApplySorting(request.sort) 
                    : query = query.OrderBy(c => c.Id);
            
            int count = query.Count();

            var pages = ((int)Math.Ceiling((double)count / request.Limit));
            /**var data = await query.AsNoTracking()
                            .Skip((request.Page - 1) * request.Limit)
                            .Take(request.Limit).ProjectTo<ArticuloExistenciaDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);**/
            var data = await query.AsNoTracking()
                            .ProjectTo<ArticuloExistenciaDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);
            var vm = new GetAllArticuloResponse
            {
                Data = data,
                Count = count,
                Pages = pages
            };

            return vm;

        }
    }
}
