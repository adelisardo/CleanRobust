
namespace CleanRobust.Application.Customers.Commands.UpdateCustomer;

public class UpdateCustomerHandler :  IRequestHandler<UpdateCustomerCommand, Guid>
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
        throw new NotImplementedException();
    }
}
