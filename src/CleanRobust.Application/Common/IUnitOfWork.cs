namespace CleanRobust.Application.Common;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    public Task<Result> SaveChangesAsync(CancellationToken cancellationToken = default);
}