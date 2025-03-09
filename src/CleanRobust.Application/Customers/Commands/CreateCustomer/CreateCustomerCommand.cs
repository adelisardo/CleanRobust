namespace CleanRobust.Application.Customers.Commands.CreateCustomer;

public record CreateCustomerCommand : IRequest<Guid>
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }
}
