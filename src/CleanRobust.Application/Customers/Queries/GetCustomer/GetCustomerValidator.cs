namespace CleanRobust.Application.Customers.Queries.GetCustomer;

public class GetCustomerValidator : AbstractValidator<GetCustomerQuery>
{
    public GetCustomerValidator()
    {
        RuleFor(c => c.Id).NotNull().WithName("Id");
    }
}
