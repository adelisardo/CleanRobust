namespace CleanRobust.Application.Customers.Queries.SearchCustomer;

public record SearchCustomerQuery(string Keyword) : IRequest<List<SearchCustomerDTO>>;