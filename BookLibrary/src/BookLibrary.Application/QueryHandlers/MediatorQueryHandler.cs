using BookLibrary.Domain.Events;
using BookLibrary.Domain.Queries;
using MediatR;

namespace BookLibrary.Application.QueryHandlers
{
    public abstract class MediatorQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
         where TQuery : Query<TResponse>
         where TResponse : class
    {
        protected MediatorQueryHandler(IMediatorHandler mediator)
        {
            Mediator = mediator;
        }

        protected IMediatorHandler Mediator { get; }
        protected IEnumerable<string> Errors { get; }

        public abstract Task<TResponse> AfterValidation(TQuery request);
        public Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);

                return Task.FromResult<TResponse>(null);
            }

            return AfterValidation(request);
        }

        protected void NotifyValidationErrors(TQuery message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                Mediator.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        protected bool HasNotifications() => Mediator.HasNotification();
        protected void NotifyError(string message)
        {
            Mediator.RaiseEvent(new DomainNotification(string.Empty, message));
        }
    }
}
