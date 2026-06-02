using BankingApplication.Application.Command;
using BankingApplication.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController(IMediator mediator) : ControllerBase
    {
        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit(DepositCommand command)
        {
            var amount = await mediator.Send(command);
            return Ok(amount);
        }
        [HttpPost("Withdraw")]
        public async Task<IActionResult> Withdraw(WithdrawCommand command)
        {
            var amount = await mediator.Send(command);
            return Ok(amount);
        }
        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer(TransferCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }
        [HttpGet("history/{accountNo}")]
        public async Task<IActionResult> History([FromRoute]GetTransactionHistoryQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
