using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Interfaces;
using Ophelia.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandQueries.TipoDocumentos.Command.Create
{
    public class CreateTipoDocumentoHandler : CommandRequestHandler<CreateTipoDocumentoRequest, TipoDocumentoDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreateTipoDocumentoHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<TipoDocumentoDto> HandleCommand(CreateTipoDocumentoRequest request, CancellationToken cancellationToken)
        {
            TipoDocumento tipodocumento = new TipoDocumento
            {
                Id = request.Id,
                Detalle = request.Detalle
            };
            _context.tipodocumentos.Add(tipodocumento);
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
            var vm = _mapper.Map<TipoDocumentoDto>(tipodocumento);
            return vm;
        }
    }
}

