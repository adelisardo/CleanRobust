

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
        throw new NotImplementedException();
    }
}
