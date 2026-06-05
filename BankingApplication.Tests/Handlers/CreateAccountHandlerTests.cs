using BankingApplication.Application.Command;
using BankingApplication.Application.Handler;
using BankingApplication.Application.Interfaces;
using BankingApplication.Domain.AccountFactory.Interface;
using BankingApplication.Domain.Entities;
using BankingApplication.Domain.Enums;
using Moq;

namespace BankingApplication.Tests.Handlers;

public class CreateAccountHandlerTests
{
    private readonly Mock<IUnitOfWork> _uowMock;
    private readonly Mock<IAccountFactoryProvider> _providerMock;
    private readonly Mock<IAccountFactory> _factoryMock;
    private readonly Mock<IAccountRepository> _accountRepoMock;

    private readonly CreateAccountHandler _handler;

    public CreateAccountHandlerTests()
    {
        _uowMock = new Mock<IUnitOfWork>();
        _providerMock = new Mock<IAccountFactoryProvider>();
        _factoryMock = new Mock<IAccountFactory>();
        _accountRepoMock = new Mock<IAccountRepository>();

        _uowMock.Setup(x => x.Account).Returns(_accountRepoMock.Object);

        _handler = new CreateAccountHandler( _uowMock.Object,_providerMock.Object);
    }
    [Fact]
    public async Task Handle_ShouldReturnAccountNumber()
    {
        var customerId = Guid.NewGuid();

        var account = new SavingAccount
        {
            AccountNo = "101"
        };

        _providerMock.Setup(x => x.GetFactory(AccountType.Savings)).Returns(_factoryMock.Object);

        _factoryMock.Setup(x => x.CreateAccount("101", customerId)).Returns(account);

        var command = new CreateAccountCommand
        {
            AccountNo = "101",
            CustomerId = customerId,
            AccountType = AccountType.Savings
        };

        var result = await _handler.Handle(command,CancellationToken.None);

        Assert.Equal("101", result);
    }
}
