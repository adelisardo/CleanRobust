
namespace CleanRobust.Application.Common;

public interface IAppUnitOfWork : IUnitOfWork
{
    public DbSet<Customer> Customers { get; }
}
