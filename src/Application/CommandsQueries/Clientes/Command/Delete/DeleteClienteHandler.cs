﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ophelia.Application.Common.Abstracts;
using Ophelia.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandQueries.Clientes.Command.Delete
{
    public class DeleteClienteHandler : CommandRequestHandler<DeleteClienteRequest, ClienteDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public DeleteClienteHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ClienteDto> HandleCommand(DeleteClienteRequest request, CancellationToken cancellationToken)
        {
            
            var entity = await _context.clientes.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            var vm = _mapper.Map<ClienteDto>(entity);
            _context.clientes.Remove(entity);
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

