using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanRobust.Application;
public interface ICustomerService
{
    List<Domain.Entities.Customer> GetAll();
}
