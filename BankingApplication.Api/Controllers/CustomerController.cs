using BankingApplication.Application.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankingApplication.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateCustomer(CreateCustomerCommand command)
    {
        var customerId = await mediator.Send(command);
        return Ok(customerId);
    }
}
