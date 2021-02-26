using Ophelia.Application.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Ophelia.Application.Common.Abstracts
{
    public abstract class CommandRequest<TData> : IRequest<CommandResult<TData>>
    {
        [IgnoreDataMember]
        public bool Transaction { get; set; }
        public CommandRequest(bool transaction = false) 
        {
            Transaction = transaction;
        }
    }
}
