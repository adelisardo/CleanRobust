
namespace CleanRobust.Application.Customers.Commands.DeleteCustomer;

public class DeleteCustomerHandler :  IRequestHandler<DeleteCustomerCommand, Guid>
{
    private IAppUnitOfWork _dbContext;
    public DeleteCustomerHandler(IAppUnitOfWork dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer  = _dbContext.Customers.FirstOrDefault(c => c.Id == request.Id);
        if (customer == null)
            throw new Exception("Threre is no customer.");

        customer.Delete();
        _dbContext.Customers.Remove(customer);
        
        await _dbContext.SaveChangesAsync(cancellationToken);

        return customer.Id;
    }
}
