using CleanRobust.Application;
using Microsoft.AspNetCore.Mvc;

namespace CleanRobust.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService CustomerService;

    public CustomerController(ICustomerService customerService)
    {
        CustomerService = customerService;
    }

    [HttpGet]
    public ActionResult<IList<Domain.Entities.Customer>> Get()
    {
        return Ok(CustomerService.GetAll());
    }
}
