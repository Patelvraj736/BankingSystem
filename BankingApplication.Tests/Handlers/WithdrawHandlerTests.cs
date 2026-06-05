using BankingApplication.Application.Command;
using BankingApplication.Application.Handler;
using BankingApplication.Application.Interfaces;
using BankingApplication.Domain.Entities;
using Moq;

namespace BankingApplication.Tests.Handlers;

public class WithdrawHandlerTests
{
    private readonly Mock<IUnitOfWork> _uowMock;
    private readonly Mock<IAccountRepository> _accountRepoMock;
    private readonly WithdrawHandler _handler;
    private readonly Mock<ITransactionRepository> _transactionRepoMock;

    public WithdrawHandlerTests()
    {
        _uowMock = new Mock<IUnitOfWork>();
        _accountRepoMock = new Mock<IAccountRepository>();
        _transactionRepoMock = new Mock<ITransactionRepository>();

        _uowMock.Setup(x => x.Account).Returns(_accountRepoMock.Object);
        _uowMock.Setup(x => x.Transaction).Returns(_transactionRepoMock.Object);

        _handler = new WithdrawHandler(_uowMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldWithdraw()
    {
        var account = new SavingAccount
        {
            AccountNo = "101",
            Balance = 500
        };
        _accountRepoMock.Setup(x => x.GetByAccountNumber("101")).ReturnsAsync(account);
        var command = new WithdrawCommand()
        {
            AccountNo="101",
            Amount=100
        };
        var result = await _handler.Handle(command, CancellationToken.None);
        Assert.Equal(400, result);
    }
    [Fact]
    public async Task Handle_ShouldCallSaveChangesAsync()
    {
        var account = new SavingAccount
        {
            AccountNo = "101",
            Balance = 500
        };
        _accountRepoMock.Setup(x => x.GetByAccountNumber("101")).ReturnsAsync(account);
        var command = new WithdrawCommand()
        {
            AccountNo = "101",
            Amount = 100
        };
        var result = await _handler.Handle(command, CancellationToken.None);

        _uowMock.Verify(x => x.SaveChangesAsync(), Times.Once);
    }
}
