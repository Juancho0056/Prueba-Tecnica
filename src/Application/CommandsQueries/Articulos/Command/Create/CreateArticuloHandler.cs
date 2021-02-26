using Application.CommandQueries.Unidades;
using Application.CommandsQueries.Articulos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Interfaces;
using Ophelia.Application.Common.Results;
using Ophelia.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandQueries.Articulos.Command.Create
{
    public class CreateArticuloHandler : CommandRequestHandler<CreateArticuloRequest, ArticuloExistenciaDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreateArticuloHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ArticuloExistenciaDto> HandleCommand(CreateArticuloRequest request, CancellationToken cancellationToken)
        {
            var unidad = _context.unidades.
                    AsNoTracking().
                    Where(x => x.Id == request.Articulo.UnidadId).FirstOrDefault();
            var vm = new ArticuloExistenciaDto();
            Articulo articulo = new Articulo
            {
                Detalle = request.Articulo.Detalle,
                UnidadId = request.Articulo.UnidadId,
                Precio = request.Articulo.Precio
            };
            _context.articulos.Add(articulo);
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
                Existencia existencia = new Existencia()
                {
                    Articulo = articulo,
                    ArticuloId = articulo.Id,
                    ExistenciaMaxima = request.ExistenciaMaxima,
                    ExistenciaMinima = request.ExistenciaMinima,
                    CantDisponible = request.CantDisponible
                };
                _context.existencias.Add(existencia);
                await _context.SaveChangesAsync(cancellationToken);
                vm = _mapper.Map<ArticuloExistenciaDto>(existencia);
                var unidadArticulo = _mapper.Map<UnidadDto>(unidad);
                vm.Articulo.Unidad = unidadArticulo;
            }
            catch (DbUpdateConcurrencyException)
            {
                _context.RollbackTransaction();
                _context.DetachAll();
                return await HandleCommand(request, cancellationToken);
            }
            return vm;
        }

        public override async Task<CommandResult<ArticuloExistenciaDto>> Handle(CreateArticuloRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Transaction) await _context.BeginTransactionAsync();
                var vm = await HandleCommand(request, cancellationToken);
                if (request.Transaction) await _context.CommitTransactionAsync();

                return CommandResult<ArticuloExistenciaDto>.Ok(vm);
            }
            catch (Exception e)
            {
                if (request.Transaction) _context.RollbackTransaction();
                return CommandResult<ArticuloExistenciaDto>.Fail(e.Message);
            }
        }
    }
}

