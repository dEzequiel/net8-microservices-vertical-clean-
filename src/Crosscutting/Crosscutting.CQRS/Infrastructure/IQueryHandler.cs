using Crosscutting.CQRS.Domain;
using MediatR;

namespace Crosscutting.CQRS.Infrastructure
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
        where TResponse : notnull
    {
    }
}
