
namespace CleanRobust.Application.Customers.Queries.GetCustomer;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerDTO>
{
    private IAppUnitOfWork _dbContext;
    private IMapper _mapper;
    public GetCustomerQueryHandler(IAppUnitOfWork dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GetCustomerDTO> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        return await _mapper.ProjectTo<GetCustomerDTO>
            (_dbContext.Customers.Where(c => c.Id == request.Id))
            .FirstOrDefaultAsync(cancellationToken);
    }
}
