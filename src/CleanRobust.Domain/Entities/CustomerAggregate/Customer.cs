using CleanRobust.Domain.Entities.CustomerAggregate.Events;

namespace CleanRobust.Domain.Entities.CustomerAggregate;

public class Customer : EntityBase, IAggregateRoot
{
    public string Firstname { get; private set; }
    public string Lastname { get; private set; }
    public DateOnly DateOfBirth { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string BankAccountNumber { get; private set; }

    public Customer() { }
    public Customer(string firstname, string lastname, DateOnly dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
    {
        Firstname = firstname;
        Lastname = lastname;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;

        AddDomainEvent(new CustomerCreatedEvent(Id, Firstname, Lastname, DateOfBirth, PhoneNumber, Email, BankAccountNumber));
    }

    public void Update(string firstname, string lastname, DateOnly dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
    {
        Firstname = firstname;
        Lastname = lastname;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;

        AddDomainEvent(new CustomerUpdatedEvent(Id, Firstname, Lastname, DateOfBirth, PhoneNumber, Email, BankAccountNumber));
    }
    public void Delete()
    {
        if (IsDeleted) return;

        IsDeleted = true;
        AddDomainEvent(new CustomerDeletedEvent(Id, Firstname, Lastname, DateOfBirth, PhoneNumber, Email, BankAccountNumber));
    }
}
