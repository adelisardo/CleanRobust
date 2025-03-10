using CleanRobust.Domain.Common;
using CleanRobust.Domain.Entities.CustomerAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.Json;

namespace CleanRobust.Infrastructure.UnitOfWork;

public class AppUnitOfWork : IAppUnitOfWork
{
    public DbSet<EventStore> EventStores => _dbContext.Set<EventStore>();
    public DbSet<Customer> Customers => _dbContext.Set<Customer>();

    private AppDbContext _dbContext;
    public AppUnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var strategy = _dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await _dbContext.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

                try
                {
                    var (domainEvents, eventStores) = BeforeSaveChanges();

                    var rowsAffected = await _dbContext.SaveChangesAsync();

                    await transaction.CommitAsync();

                    await AfterSaveChangesAsync(domainEvents, eventStores);
                }
                catch
                {

                    await transaction.RollbackAsync();
                    throw;
                }
            });
            return Result.Success();
        }
        catch (DbUpdateConcurrencyException e)
        {
            return Result.Fail(e.Message);
        }
        catch (DbUpdateException e)
        {
            return Result.Fail(e.Message);
        }
    }

    private (IReadOnlyList<EventBase> domainEvents, IReadOnlyList<EventStore> eventStores) BeforeSaveChanges()
    {
        var domainEntities = _dbContext.ChangeTracker
            .Entries<EntityBase>()
            .Where(entry => entry.Entity.DomainEvents.Any())
            .ToList();

        var domainEvents = domainEntities
            .SelectMany(entry => entry.Entity.DomainEvents)
            .ToList();

        var eventStores = domainEvents.ConvertAll(@event => new EventStore(@event.AggregateId, @event.GetGenericTypeName(), @event.ToJson()));

        domainEntities.ForEach(entry => entry.Entity.ClearDomainEvents());

        return (domainEvents.AsReadOnly(), eventStores.AsReadOnly());
    }

    private async Task AfterSaveChangesAsync(IReadOnlyList<EventBase> domainEvents, IReadOnlyList<EventStore> eventStores)
    {
        //if (domainEvents.Count > 0)
        //    await Task.WhenAll(domainEvents.Select(@event => _mediator.Publish(@event)));

        if (eventStores.Count > 0)
        {
            await EventStores.AddRangeAsync(eventStores);
            await _dbContext.SaveChangesAsync();
        }
    }

    public void Dispose()
    {
        _dbContext.Dispose();
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        await _dbContext.DisposeAsync();
        GC.SuppressFinalize(this);
    }
}
