using Ophelia.Application.Common.Results;
using MediatR;

namespace Ophelia.Application.Common.Abstracts
{
    public abstract class QueryRequest<TData> : EnumerableRequest, IRequest<QueryResult<TData>>
    {
    }
}