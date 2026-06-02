using BankingApplication.Application.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankingApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController(IMediator mediator) : ControllerBase
    {
        [HttpPost("apply")]
        public async Task<IActionResult> ApplyLoan(ApplyLoanCommand command)
        {
            var loanId = await mediator.Send(command);
            return Ok(loanId);
        }
    }
}
