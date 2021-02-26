using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Interfaces;
using Ophelia.Application.Common.Results;
using Ophelia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandQueries.Ventas.Command.Create
{
    public class CreateVentaHandler : CommandRequestHandler<CreateVentaRequest, VentaDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreateVentaHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<VentaDto> HandleCommand(CreateVentaRequest request, CancellationToken cancellationToken)
        {
            var detalles= new List<DetalleVentaDto>();
            var vlrVenta = request.Detalles.Sum(x => x.Valor);
            Venta venta = new Venta
            {
                FechaVenta = request.FechaVenta,
                ClienteId = request.ClienteId,
                VlrVenta = vlrVenta
            };
            _context.ventas.Add(venta);
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
                foreach (var detalle in request.Detalles) 
                {
                    DetalleVenta detalleVenta = new DetalleVenta()
                    {
                        VentaId = venta.Id,
                        ArticuloId = detalle.ArticuloId,
                        Cantidad = detalle.Cantidad,
                        Valor = detalle.Valor
                    };
                    _context.detalleventas.Add(detalleVenta);
                    detalles.Add(_mapper.Map<DetalleVentaDto>(detalleVenta));
                }
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                _context.RollbackTransaction();
                _context.DetachAll();
                return await HandleCommand(request, cancellationToken);
            }
            var vm = _mapper.Map<VentaDto>(venta);
            vm.Detalles = detalles;
            return vm;
        }
        public override async Task<CommandResult<VentaDto>> Handle(CreateVentaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if(request.Transaction) await _context.BeginTransactionAsync();
                var vm = await HandleCommand(request, cancellationToken);
                if(request.Transaction )await _context.CommitTransactionAsync();

                return CommandResult<VentaDto>.Ok(vm);
            }
            catch (Exception e)
            {
                if(request.Transaction) _context.RollbackTransaction();
                return CommandResult<VentaDto>.Fail(e.Message);
            }
        }
    }
}

