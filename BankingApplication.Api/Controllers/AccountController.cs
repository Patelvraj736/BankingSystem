using BankingApplication.Application.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankingApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAccount(CreateAccountCommand command)
        {
            var accountNo = await mediator.Send(command);
            return Ok(accountNo);
        }
    }
}
