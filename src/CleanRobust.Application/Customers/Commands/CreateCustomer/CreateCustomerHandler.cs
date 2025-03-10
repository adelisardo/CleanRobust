
using CleanRobust.Domain.Entities.CustomerAggregate;

namespace CleanRobust.Application.Customers.Commands.CreateCustomer;

public class CreateCustomerHandler :  IRequestHandler<CreateCustomerCommand, Guid>
{
    private IAppUnitOfWork _dbContext;
    private IMapper _mapper;
    public CreateCustomerHandler(IAppUnitOfWork dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var obj = _mapper.Map<Customer>(request);
        _dbContext.Customers.Add(obj);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return obj.Id;
    }
}
