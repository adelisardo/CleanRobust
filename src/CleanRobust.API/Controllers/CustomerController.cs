using CleanRobust.API.Common;
using CleanRobust.Application.Customers.Commands.CreateCustomer;
using CleanRobust.Application.Customers.Commands.DeleteCustomer;
using CleanRobust.Application.Customers.Commands.UpdateCustomer;
using CleanRobust.Application.Customers.Queries.GetCustomer;
using CleanRobust.Application.Customers.Queries.SearchCustomer;
using Microsoft.AspNetCore.Mvc;

namespace CleanRobust.API.Controllers;

public class CustomerController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<List<SearchCustomerDTO>>> Search([FromQuery] SearchCustomerQuery query) => await Mediator.Send(query);

    [HttpGet("{id}")]
    public async Task<ActionResult<GetCustomerDTO>> Get(Guid id) => await Mediator.Send(new GetCustomerQuery(id));

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateCustomerCommand command) => await Mediator.Send(command);

    [HttpPut]
    public async Task<ActionResult<Guid>> Update(UpdateCustomerCommand command) => await Mediator.Send(command);

    [HttpDelete("{id}")]
    public async Task<ActionResult<int>> Delete(Guid id) => await Mediator.Send(new DeleteCustomerCommand(id));

}
