namespace CleanRobust.Application.Customers.Queries.SearchCustomer;

public record SearchCustomerDTO
{
    public Guid Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
}
