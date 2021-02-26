using Application.CommandQueries.Existencias;
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

namespace Application.CommandsQueries.Existencias.Queries.GetAll
{
    public class GetAllExistenciaHandler : QueryRequestHandler<GetAllExistenciaRequest, GetAllExistenciaResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllExistenciaHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<GetAllExistenciaResponse> HandleQuery(GetAllExistenciaRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Existencia> query = (from v in _context.existencias
                                        orderby v.FechaCreacion descending
                                        select v);
            if (request.Id > 0)
            {
                query = query.Where(v => v.Id.ToString().Contains(request.Id.ToString()));
            }
            if (!string.IsNullOrEmpty(request.Detalle))
            {
                query = query.Where(v => v.Articulo.Detalle.ToLower().Contains(request.Detalle.ToLower()) );
            }
            if (request.ArticuloId > 0)
            {
                query = query.Where(v => v.Articulo.Id.ToString().Contains(request.ArticuloId.ToString()));
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
            var data = await query.AsNoTracking()
                            .Skip((request.Page - 1) * request.Limit)
                            .Take(request.Limit).ProjectTo<ExistenciaDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);

            var vm = new GetAllExistenciaResponse
            {
                Data = data,
                Count = count,
                Pages = pages
            };

            return vm;

        }
    }
}
