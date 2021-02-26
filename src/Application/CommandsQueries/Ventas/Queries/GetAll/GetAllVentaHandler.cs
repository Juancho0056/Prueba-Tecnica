using Application.CommandQueries.Ventas;
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

namespace Application.CommandsQueries.Ventas.Queries.GetAll
{
    public class GetAllVentaHandler : QueryRequestHandler<GetAllVentaRequest, GetAllVentaResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllVentaHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<GetAllVentaResponse> HandleQuery(GetAllVentaRequest request, CancellationToken cancellationToken)
        {
            var query =await (from v in _context.ventas
                                        orderby v.FechaCreacion descending
                                        select new VentaDto
                                        {
                                            Id = v.Id,
                                            ClienteId = v.ClienteId,
                                            FechaVenta = v.FechaVenta,
                                            NombreCliente = v.Cliente.NroDocumento + "-" + v.Cliente.PrimerNombre,
                                            VlrVenta = v.VlrVenta,
                                            Detalles = (from dt in v.DetalleFactura
                                                       select new DetalleVentaDto 
                                                       {
                                                           VentaId = dt.VentaId,
                                                           ArticuloId = dt.ArticuloId,
                                                           Cantidad = dt.Cantidad,
                                                           Valor = dt.Valor
                                                       }).ToList()
                                        }).ToListAsync();

            /**if (request.Id > 0)
            {
                query = query.Where(v => v.Id.ToString().Contains(request.Id.ToString()));
            }
            if (request.ClienteId > 0)
            {
                query = query.Where(v => v.ClienteId == request.ClienteId);
            }
            if (request.FechaVenta != DateTime.MinValue)
            {
                query = query.Where(v => v.FechaVenta == request.FechaVenta);
            }
            if (request.EstadoRegistro != null)
            {
                query = query.Where(v => v.EstadoRegistro.Equals(request.EstadoRegistro));
            }
            if(request.sort != null)                         
                query = request.sort.Length > 0 ? query = query.ApplySorting(request.sort) 
                    : query = query.OrderBy(c => c.Id);**/
            
            /**int count = query.Count();**/

            /**var pages = ((int)Math.Ceiling((double)count / request.Limit));
            var data = await query.AsNoTracking()
                            .Skip((request.Page - 1) * request.Limit)
                            .Take(request.Limit).ProjectTo<VentaDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);**/

            var vm = new GetAllVentaResponse
            {
                Data = query,
                Count = 0,
                Pages = 0
            };

            return vm;

        }
    }
}
