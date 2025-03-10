

using AutoMapper.QueryableExtensions;
using CleanRobust.Application.Customers.Queries.GetCustomer;

namespace CleanRobust.Application.Customers.Queries.SearchCustomer;

public class SearchCustomerQueryHandler : IRequestHandler<SearchCustomerQuery, List<SearchCustomerDTO>>
{
    private IAppUnitOfWork _dbContext;
    private IMapper _mapper;
    public SearchCustomerQueryHandler(IAppUnitOfWork dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<SearchCustomerDTO>> Handle(SearchCustomerQuery request, CancellationToken cancellationToken)
    {
        var query = _dbContext.Customers.AsQueryable();
        if (!string.IsNullOrWhiteSpace(request.Keyword))
        {
            query = query.Where(c => c.Firstname.Contains(request.Keyword) || c.Lastname.Contains(request.Keyword));
        }
        return await _mapper.ProjectTo<SearchCustomerDTO>(query).ToListAsync(cancellationToken);
    }
}
