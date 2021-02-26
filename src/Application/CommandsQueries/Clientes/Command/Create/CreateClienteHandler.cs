using Application.CommandQueries.TipoDocumentos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Interfaces;
using Ophelia.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandQueries.Clientes.Command.Create
{
    public class CreateClienteHandler : CommandRequestHandler<CreateClienteRequest, ClienteDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreateClienteHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ClienteDto> HandleCommand(CreateClienteRequest request, CancellationToken cancellationToken)
        {
            var tipo = _context.tipodocumentos.
            AsNoTracking().
            Where(x => x.Id == request.TipoDocumentoId).FirstOrDefault();
            Cliente cliente = new Cliente
            {
                TipoDocumentoId = request.TipoDocumentoId,
                NroDocumento = request.NroDocumento,
                PrimerNombre = request.PrimerNombre,
                SegundoNombre = request.SegundoNombre,
                FechaNacimiento = request.FechaNacimiento
            };
            _context.clientes.Add(cliente);
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
            var tipoDocumento = _mapper.Map<TipoDocumentoDto>(tipo);
            
            var vm = _mapper.Map<ClienteDto>(cliente);
            vm.TipoDocumento = tipoDocumento;
            return vm;
        }
    }
}

