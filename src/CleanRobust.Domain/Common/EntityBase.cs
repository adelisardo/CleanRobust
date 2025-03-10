using System.ComponentModel.DataAnnotations.Schema;

namespace CleanRobust.Domain.Common;

public abstract class EntityBase
{
    public EntityBase() => Id = Guid.NewGuid();
    protected EntityBase(Guid id) => Id = id;

    private readonly List<EventBase> _domainEvents = [];
    protected bool IsDeleted;

    public Guid Id { get; private init; }
    [NotMapped]
    public IEnumerable<EventBase> DomainEvents => _domainEvents.AsReadOnly();
    protected void AddDomainEvent(EventBase domainEvent) => _domainEvents.Add(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear();
}
