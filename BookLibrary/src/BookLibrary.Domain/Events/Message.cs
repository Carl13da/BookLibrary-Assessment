using BookLibrary.Domain.Interfaces.Events;
using MediatR;

namespace BookLibrary.Domain.Events
{
    public abstract class Message : IRequest, IRequestBase
    {
        protected Message()
        {
            MessageType = GetType().Name;
        }

        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }
    }
}
