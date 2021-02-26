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

namespace Application.CommandQueries.Articulos.Command.Delete
{
    public class DeleteArticuloHandler : CommandRequestHandler<DeleteArticuloRequest, ArticuloExistenciaDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public DeleteArticuloHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ArticuloExistenciaDto> HandleCommand(DeleteArticuloRequest request, CancellationToken cancellationToken)
        {
            
            var entity = await _context.articulos.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            var entityExistencia = await _context.existencias.Where(x => x.ArticuloId == request.Id).FirstOrDefaultAsync(cancellationToken);
            var vm = _mapper.Map<ArticuloExistenciaDto>(entityExistencia);
            _context.existencias.Remove(entityExistencia);
            _context.articulos.Remove(entity);
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

