using CleanRobust.Application;
using CleanRobust.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanRobust.Infrastructure;
public class CustomerRepository : ICustomerRepository
{
    private static List<Customer> Customers = new()
    {
        new(){Id = Guid.NewGuid() , Firstname = "Mehdi" , Lastname  = "Adeli" , PhoneNumber = "+989383414980" , Email = "adelisardo@gmail.com" ,  DateOfBirth=new DateOnly(1983,9,19) , BankAccountNumber = "6104337841639022"}
    };

    public List<Customer> GetAll()
    {
        return Customers;
    }
}
