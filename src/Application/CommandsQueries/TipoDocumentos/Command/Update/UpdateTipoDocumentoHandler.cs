using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandQueries.TipoDocumentos.Command.Update
{
    public class UpdateTipoDocumentoHandler : CommandRequestHandler<UpdateTipoDocumentoRequest, TipoDocumentoDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UpdateTipoDocumentoHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<TipoDocumentoDto> HandleCommand(UpdateTipoDocumentoRequest request, CancellationToken cancellationToken)
        {
            
            var entity = await _context.tipodocumentos.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (!string.IsNullOrEmpty(request.Detalle)) 
            {
                entity.Detalle = request.Detalle;
            }
            entity.EstadoRegistro = request.EstadoRegistro ?? true;
            _context.tipodocumentos.Update(entity);
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
            var vm = _mapper.Map<TipoDocumentoDto>(entity);
            return vm;
        }
    }
}

