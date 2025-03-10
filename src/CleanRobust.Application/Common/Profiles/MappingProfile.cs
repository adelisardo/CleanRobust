using CleanRobust.Application.Customers.Commands.CreateCustomer;
using CleanRobust.Application.Customers.Commands.UpdateCustomer;
using CleanRobust.Application.Customers.Queries.GetCustomer;
using CleanRobust.Application.Customers.Queries.SearchCustomer;
using CleanRobust.Domain.Entities.CustomerAggregate;

namespace CleanRobust.Application.Common.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCustomerCommand, Customer>();
        CreateMap<UpdateCustomerCommand, Customer>();
        CreateMap<Customer, SearchCustomerDTO>();
        CreateMap<Customer, GetCustomerDTO>();
    }
}
