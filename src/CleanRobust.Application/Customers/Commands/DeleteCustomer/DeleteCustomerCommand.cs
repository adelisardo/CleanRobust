namespace CleanRobust.Application.Customers.Commands.DeleteCustomer;

public record DeleteCustomerCommand(Guid? Id) : IRequest<int>;
