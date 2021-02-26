using Application.CommandQueries.Clientes;
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

namespace Application.CommandsQueries.Clientes.Queries.GetAll
{
    public class GetAllClienteHandler : QueryRequestHandler<GetAllClienteRequest, GetAllClienteResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllClienteHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<GetAllClienteResponse> HandleQuery(GetAllClienteRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Cliente> query = (from v in _context.clientes
                                        orderby v.PrimerNombre descending
                                        select v);
            if (request.Id != null && request.Id > 0)
            {
                query = query.Where(v => v.Id.ToString().Contains(request.Id.ToString()));
            }
            if (!string.IsNullOrEmpty(request.NroDocumento))
            {
                query = query.Where(v => v.NroDocumento.ToLower().Contains(request.NroDocumento.ToLower()));
            }
            if (!string.IsNullOrEmpty(request.PrimerNombre))
            {
                query = query.Where(v => v.PrimerNombre.ToLower().Contains(request.PrimerNombre.ToLower()) );
            }
            if (!string.IsNullOrEmpty(request.SegundoNombre))
            {
                query = query.Where(v => v.SegundoNombre.ToLower().Contains(request.SegundoNombre.ToLower()));
            }
            if (request.FechaNacimiento != null && request.FechaNacimiento != DateTime.MinValue)
            {
                query = query.Where(v => v.FechaNacimiento == request.FechaNacimiento);
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
                            .Take(request.Limit).ProjectTo<ClienteDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);**/
            var data = await query.AsNoTracking()
                           .ProjectTo<ClienteDto>(_mapper.ConfigurationProvider)
                           .ToListAsync(cancellationToken);
            var vm = new GetAllClienteResponse
            {
                Data = data,
                Count = count,
                Pages = pages
            };

            return vm;

        }
    }
}
