using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandQueries.Existencias.Command.Delete
{
    public class DeleteExistenciaHandler : CommandRequestHandler<DeleteExistenciaRequest, ExistenciaDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public DeleteExistenciaHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ExistenciaDto> HandleCommand(DeleteExistenciaRequest request, CancellationToken cancellationToken)
        {
            
            var entity = await _context.existencias.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            var vm = _mapper.Map<ExistenciaDto>(entity);
            _context.existencias.Remove(entity);
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
            return vm;
        }
    }
}

