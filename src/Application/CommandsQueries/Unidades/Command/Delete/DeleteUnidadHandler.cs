using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandQueries.Unidades.Command.Delete
{
    public class DeleteUnidadHandler : CommandRequestHandler<DeleteUnidadRequest, UnidadDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public DeleteUnidadHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<UnidadDto> HandleCommand(DeleteUnidadRequest request, CancellationToken cancellationToken)
        {
            
            var entity = await _context.unidades.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            var vm = _mapper.Map<UnidadDto>(entity);
            _context.unidades.Remove(entity);
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

