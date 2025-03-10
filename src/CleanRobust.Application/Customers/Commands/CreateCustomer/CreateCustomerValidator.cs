using PhoneNumbers;

namespace CleanRobust.Application.Customers.Commands.CreateCustomer;

public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
{
    private IAppUnitOfWork _dbContext;
    public CreateCustomerValidator(IAppUnitOfWork dbContext)
    {
        _dbContext = dbContext;

        RuleFor(c => c.Firstname).NotEmpty().MaximumLength(20).WithName("First name");
        RuleFor(c => c.Lastname).NotEmpty().MaximumLength(20).WithName("Last name");
        RuleFor(c => c.DateOfBirth).NotNull().WithName("Date of birth");
        RuleFor(c => c.PhoneNumber).MaximumLength(50).Must((obj, c) => IsValidPhoneNumber(obj, c)).WithName("Phone number");
        RuleFor(c => c.Email).NotEmpty().MaximumLength(50).EmailAddress().WithName("Email").Must((obj,c) => IsUniqueEmail(obj, c)).WithMessage("A customer with the same Email already exists.");
        RuleFor(c => c.BankAccountNumber).NotEmpty().MaximumLength(50).WithName("Bank account number");
        RuleFor(c => c.Firstname).Must((obj, c) => IsUnique(obj, c)).WithMessage("A customer with the same First name, Last name and Date of birth already exists.");
    }

    private bool IsValidPhoneNumber(CreateCustomerCommand obj, string phoneNumber)
    {
        try
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            var number = phoneNumberUtil.Parse(phoneNumber, null);
            return phoneNumberUtil.IsValidNumber(number);
        }
        catch
        {
            return false;
        }
    }
    private bool IsUniqueEmail(CreateCustomerCommand obj, string email)
    {
        return !(_dbContext.Customers.Any(c => c.Email == email));
    }
    private bool IsUnique(CreateCustomerCommand obj, string firstName)
    {
        return !(_dbContext.Customers.Any(c =>
                    c.Firstname == obj.Firstname &&
                    c.Lastname == obj.Lastname &&
                    c.DateOfBirth == obj.DateOfBirth));
    }
}
