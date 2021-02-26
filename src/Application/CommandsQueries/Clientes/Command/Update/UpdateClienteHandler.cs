using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandQueries.Clientes.Command.Update
{
    public class UpdateClienteHandler : CommandRequestHandler<UpdateClienteRequest, ClienteDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UpdateClienteHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ClienteDto> HandleCommand(UpdateClienteRequest request, CancellationToken cancellationToken)
        {
            var entity = await _context.clientes.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (!string.IsNullOrEmpty(request.NroDocumento)) 
            {
                entity.NroDocumento = request.NroDocumento;
            }
            if (!string.IsNullOrEmpty(request.PrimerNombre))
            {
                entity.PrimerNombre = request.PrimerNombre;
            }
            if (!string.IsNullOrEmpty(request.SegundoNombre))
            {
                entity.PrimerNombre = request.SegundoNombre;
            }
            if (!string.IsNullOrEmpty(request.TipoDocumentoId))
            {
                entity.TipoDocumentoId = request.TipoDocumentoId;
            }
            if (request.FechaNacimiento != null && request.FechaNacimiento != DateTime.MinValue)
            {
                entity.FechaNacimiento = request.FechaNacimiento;
            }
            entity.EstadoRegistro = request.EstadoRegistro ?? true;
            _context.clientes.Update(entity);
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
            var vm = _mapper.Map<ClienteDto>(entity);
            return vm;
        }
    }
}

