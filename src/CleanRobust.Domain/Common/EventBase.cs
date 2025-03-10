namespace CleanRobust.Domain.Common;

public abstract class EventBase : INotification
{
    public string MessageType { get; protected init; }
    public Guid AggregateId { get; protected init; }
    public DateTime CreatedDateTime { get; private init; } = DateTime.Now;
}
