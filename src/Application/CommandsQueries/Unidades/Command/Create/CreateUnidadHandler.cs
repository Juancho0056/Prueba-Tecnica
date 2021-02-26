using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Interfaces;
using Ophelia.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandQueries.Unidades.Command.Create
{
    public class CreateUnidadHandler : CommandRequestHandler<CreateUnidadRequest, UnidadDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreateUnidadHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<UnidadDto> HandleCommand(CreateUnidadRequest request, CancellationToken cancellationToken)
        {
            Unidad unidad = new Unidad
            {
                Detalle = request.Detalle
            };
            _context.unidades.Add(unidad);
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
            var vm = _mapper.Map<UnidadDto>(unidad);
            return vm;
        }
    }
}

