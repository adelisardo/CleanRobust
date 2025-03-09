namespace CleanRobust.Application.Customers.Queries.GetCustomer;

public record GetCustomerQuery(Guid? Id) : IRequest<GetCustomerDTO>;