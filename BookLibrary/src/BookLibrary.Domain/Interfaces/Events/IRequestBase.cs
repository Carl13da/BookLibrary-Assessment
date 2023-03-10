namespace BookLibrary.Domain.Interfaces.Events
{
    public interface IRequestBase
    {
        string MessageType { get; }
        Guid AggregateId { get; }
    }
}
