using Application.CommandsQueries.Articulos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandQueries.Articulos.Command.Update
{
    public class UpdateArticuloHandler : CommandRequestHandler<UpdateArticuloRequest, ArticuloExistenciaDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UpdateArticuloHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ArticuloExistenciaDto> HandleCommand(UpdateArticuloRequest request, CancellationToken cancellationToken)
        {

            var entity = await _context.articulos.Where(x => x.Id == request.Articulo.Id).FirstOrDefaultAsync(cancellationToken);
            if (!string.IsNullOrEmpty(request.Articulo.Detalle)) 
            {
                entity.Detalle = request.Articulo.Detalle;
            }
            if (request.Articulo.UnidadId > 0)
            {
                entity.UnidadId = request.Articulo.UnidadId;
            }
            entity.Precio = request.Articulo.Precio;
            
            entity.EstadoRegistro = request.Articulo.EstadoRegistro ?? true;
            _context.articulos.Update(entity);

            var existencia = await _context.existencias.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            existencia.CantDisponible= request.CantDisponible;
            existencia.ExistenciaMinima = request.ExistenciaMinima;
            existencia.ExistenciaMaxima = request.ExistenciaMaxima;
            existencia.EstadoRegistro = request.EstadoRegistro ?? true;
            _context.existencias.Update(existencia);
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                _context.RollbackTransaction();
                _context.DetachAll();
                return await HandleCommand(request, cancellationToken);
            }
            var vm = _mapper.Map<ArticuloExistenciaDto>(existencia);
            return vm;
        }
    }
}

