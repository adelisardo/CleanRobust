
using CleanRobust.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanRobust.Infrastructure.UnitOfWork;

public class AppUnitOfWork : IAppUnitOfWork
{
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
            await _dbContext.SaveChangesAsync(cancellationToken);
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
