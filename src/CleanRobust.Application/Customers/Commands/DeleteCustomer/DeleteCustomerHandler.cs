
namespace CleanRobust.Application.Customers.Commands.DeleteCustomer;

public class DeleteCustomerHandler :  IRequestHandler<DeleteCustomerCommand, int>
{
    private IAppUnitOfWork _dbContext;
    public DeleteCustomerHandler(IAppUnitOfWork dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
