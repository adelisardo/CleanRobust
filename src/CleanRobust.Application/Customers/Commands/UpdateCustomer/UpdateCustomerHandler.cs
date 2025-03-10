
using CleanRobust.Domain.Entities.CustomerAggregate;

namespace CleanRobust.Application.Customers.Commands.UpdateCustomer;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, Guid>
{
    private IAppUnitOfWork _dbContext;
    private IMapper _mapper;
    public UpdateCustomerHandler(IAppUnitOfWork dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _dbContext.Customers.FirstOrDefault(c => c.Id == request.Id);
        if (customer == null)
            throw new Exception("Threre is no customer.");

        customer.Update(
            request.Firstname,
            request.Lastname,
            request.DateOfBirth.Value,
            request.PhoneNumber,
            request.Email,
            request.BankAccountNumber);

        _dbContext.Customers.Update(customer);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return customer.Id;
    }
}
