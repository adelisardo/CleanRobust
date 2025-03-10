﻿using PhoneNumbers;

namespace CleanRobust.Application.Customers.Commands.DeleteCustomer;

public class DeleteCustomerValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerValidator()
    {
        RuleFor(c => c.Id).NotNull().WithName("Id");
    }
}
