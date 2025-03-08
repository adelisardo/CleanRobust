using CleanRobust.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanRobust.Application;
public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository CustomerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        CustomerRepository = customerRepository;
    }

    public List<Customer> GetAll()
    {
        return CustomerRepository.GetAll();
    }
}
