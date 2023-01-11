using BookLibrary.Domain.Queries;
using MediatR;

namespace BookLibrary.Domain.Events
{
    public interface IMediatorHandler
    {
        void ClearNotifications();
        bool HasNotification();
        Task RaiseEvent<T>(T @event) where T : Event;
        Task<TResponse> SendQuery<TResponse>(Query<TResponse> query) where TResponse : class;
        INotificationHandler<DomainNotification> GetNotificationHandler();
    }
}
