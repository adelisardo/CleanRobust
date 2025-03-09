namespace CleanRobust.Domain.Common;

public abstract class EntityBase
{
    public EntityBase() => Id = Guid.NewGuid();

    public Guid Id { get; set; }
}
