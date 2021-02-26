using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandQueries.Existencias.Command.Update
{
    public class UpdateExistenciaHandler : CommandRequestHandler<UpdateExistenciaRequest, ExistenciaDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UpdateExistenciaHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ExistenciaDto> HandleCommand(UpdateExistenciaRequest request, CancellationToken cancellationToken)
        {
            
            var entity = await _context.existencias.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (request.CantDisponible > 0) 
            {
                entity.CantDisponible = request.CantDisponible;
            }
            entity.EstadoRegistro = request.EstadoRegistro ?? true;
            _context.existencias.Update(entity);
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
            var vm = _mapper.Map<ExistenciaDto>(entity);
            return vm;
        }
    }
}

