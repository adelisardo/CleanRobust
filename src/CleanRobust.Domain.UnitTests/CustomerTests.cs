using CleanRobust.Domain.Entities.CustomerAggregate;
using CleanRobust.Domain.Entities.CustomerAggregate.Events;


namespace CleanRobust.Domain.UnitTests;

[UnitTest]
public class CustomerTests
{
    [Fact]
    public void Should_CustomerCreatedEvent_WhenCreate()
    {
        // Arrange
        // Act
        var customer = new Faker<Customer>().CustomInstantiator(faker =>
            new Customer(
                faker.Person.FirstName,
                faker.Person.LastName,
                DateOnly.FromDateTime(faker.Person.DateOfBirth),
                faker.Person.Phone,
                faker.Person.Email,
                faker.Finance.Iban())
            ).Generate();

        // Assert
        customer.DomainEvents.Should()
            .NotBeNullOrEmpty()
            .And.OnlyHaveUniqueItems()
            .And.ContainItemsAssignableTo<CustomerCreatedEvent>();
    }

    [Fact]
    public void Should_CustomerUpdatedEvent_WhenUpdate()
    {
        // Arrange
        var customer = new Faker<Customer>().CustomInstantiator(faker =>
            new Customer(
                faker.Person.FirstName,
                faker.Person.LastName,
                DateOnly.FromDateTime(faker.Person.DateOfBirth),
                faker.Person.Phone,
                faker.Person.Email,
                faker.Finance.Iban())
            ).Generate();

        // Act
        Faker faker = new Faker();
        customer.Update(
            faker.Person.FirstName,
                faker.Person.LastName,
                DateOnly.FromDateTime(faker.Person.DateOfBirth),
                faker.Person.Phone,
                faker.Person.Email,
                faker.Finance.Iban()
            );

        // Assert
        customer.DomainEvents.Should()
            .NotBeNullOrEmpty()
            .And.OnlyHaveUniqueItems()
            .And.ContainItemsAssignableTo<CustomerUpdatedEvent>();
    }
    [Fact]
    public void Should_CustomerDeletedEvent_WhenDelete()
    {
        // Arrange
        var customer = new Faker<Customer>().CustomInstantiator(faker =>
            new Customer(
                faker.Person.FirstName,
                faker.Person.LastName,
                DateOnly.FromDateTime(faker.Person.DateOfBirth),
                faker.Person.Phone,
                faker.Person.Email,
                faker.Finance.Iban())
            ).Generate();

        // Act
        customer.Delete();

        // Assert
        customer.DomainEvents.Should()
            .NotBeNullOrEmpty()
            .And.OnlyHaveUniqueItems()
            .And.ContainItemsAssignableTo<CustomerDeletedEvent>();
    }
}