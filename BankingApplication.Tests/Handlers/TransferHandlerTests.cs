using BankingApplication.Application.Command;
using BankingApplication.Application.Handler;
using BankingApplication.Application.Interfaces;
using BankingApplication.Domain.Entities;
using Moq;

namespace BankingApplication.Tests.Handlers;

public class TransferHandlerTests
{
    private readonly Mock<IUnitOfWork> _uowMock;
    private readonly Mock<IAccountRepository>  _accountRepoMock;
    private readonly TransferHandler _handle;
    private readonly Mock<ITransactionRepository> _transactionRepoMock;

    public TransferHandlerTests()
    {
        _uowMock = new Mock<IUnitOfWork>();
        _accountRepoMock = new Mock<IAccountRepository>();
        _transactionRepoMock = new Mock<ITransactionRepository>();


        _uowMock.Setup(x => x.Account).Returns(_accountRepoMock.Object);
        _uowMock.Setup(x => x.Transaction).Returns(_transactionRepoMock.Object);

        _handle = new TransferHandler(_uowMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldTransfer()
    {
        var from = new SavingAccount
        {
            AccountNo = "101",
            Balance = 1000
        };
        var to = new SavingAccount
        {
            AccountNo = "102",
            Balance = 500
        };
        _accountRepoMock.Setup(x => x.GetByAccountNumber("101")).ReturnsAsync(from);
        _accountRepoMock.Setup(x => x.GetByAccountNumber("102")).ReturnsAsync(to);

        var command = new TransferCommand
        {
            Amount = 200,
            FromAccountNo = "101",
            ToAccountNo="102"
        };
        await _handle.Handle(command, CancellationToken.None);
        Assert.Equal(800, from.Balance);
        Assert.Equal(700, to.Balance);
    }
}
