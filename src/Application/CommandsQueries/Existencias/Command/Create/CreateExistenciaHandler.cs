using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Interfaces;
using Ophelia.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandQueries.Existencias.Command.Create
{
    public class CreateExistenciaHandler : CommandRequestHandler<CreateExistenciaRequest, ExistenciaDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreateExistenciaHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ExistenciaDto> HandleCommand(CreateExistenciaRequest request, CancellationToken cancellationToken)
        {
            Existencia existencia = new Existencia
            {
                ArticuloId = request.ArticuloId,
                ExistenciaMinima = request.ExistenciaMinima,
                ExistenciaMaxima = request.ExistenciaMaxima,
                CantDisponible = request.CantDisponible
            };
            _context.existencias.Add(existencia);
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
            var vm = _mapper.Map<ExistenciaDto>(existencia);
            return vm;
        }
    }
}

