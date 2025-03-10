namespace CleanRobust.Domain.Entities.CustomerAggregate.Events;

public class CustomerUpdatedEvent : EventBase
{
    public CustomerUpdatedEvent(Guid id, string firstname, string lastname, DateOnly dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
    {
        AggregateId = id;
     
        Id = id;
        Firstname = firstname;
        Lastname = lastname;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;
    }

    public Guid Id { get; private set; }
    public string Firstname { get; private set; }
    public string Lastname { get; private set; }
    public DateOnly DateOfBirth { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string BankAccountNumber { get; private set; }
}
