using MediatR;

namespace BookLibrary.Domain.Events
{
    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
