using BookLibrary.Domain.Interfaces.Events;
using MediatR;

namespace BookLibrary.Domain.Queries
{
    public class QueryMessage<TResponse> : IRequest<TResponse>, IBaseRequest, IRequestBase
    {
        protected QueryMessage()
        {
            MessageType = GetType().Name;
        }

        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }
    }
}
