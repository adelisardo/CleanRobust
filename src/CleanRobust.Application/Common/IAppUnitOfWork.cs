using CleanRobust.Domain.Common;
using CleanRobust.Domain.Entities.CustomerAggregate;

namespace CleanRobust.Application.Common;

public interface IAppUnitOfWork : IUnitOfWork
{
    public DbSet<EventStore> EventStores { get; }
    public DbSet<Customer> Customers { get; }
}
