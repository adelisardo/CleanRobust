namespace CleanRobust.Application.Customers.Queries.SearchCustomer;

public class SearchCustomerValidator : AbstractValidator<SearchCustomerQuery>
{
    public SearchCustomerValidator()
    {
        RuleFor(c => c.Keyword).MaximumLength(20).WithName("Keyword");
    }
}
