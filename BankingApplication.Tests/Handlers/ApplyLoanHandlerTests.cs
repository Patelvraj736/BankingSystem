using BankingApplication.Application.Command;
using BankingApplication.Application.Handler;
using BankingApplication.Application.Interfaces;
using BankingApplication.Domain.Entities;
using Moq;

namespace BankingApplication.Tests.Handlers;

public class ApplyLoanHandlerTests
{
    private readonly Mock<IUnitOfWork> _uowMock;
    private readonly Mock<ICustomerRepository> _customerRepoMock;
    private readonly Mock<ILoanRepository> _loanRepoMock;
    private readonly ApplyLoanHandler _handler;

    public ApplyLoanHandlerTests()
    {
        _uowMock = new Mock<IUnitOfWork>();
        _customerRepoMock = new Mock<ICustomerRepository>();
        _loanRepoMock = new Mock<ILoanRepository>();

        _uowMock.Setup(x => x.Loan).Returns(_loanRepoMock.Object);
        _uowMock.Setup(x => x.Customer).Returns(_customerRepoMock.Object);
        _handler = new ApplyLoanHandler(_uowMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldApplyLoan()
    {
        var customerId = Guid.NewGuid();
        var customer = new Customer
        {
            Email = "abc.com",
            Name = "Vraj"
        };
        _customerRepoMock.Setup(x => x.GetByIdAsync(customerId)).ReturnsAsync(customer);

        var command = new ApplyLoanCommand
        {
            Amount = 500,
            CustomerId = customerId
        };

        await _handler.Handle(command, CancellationToken.None);

        _loanRepoMock.Verify(x => x.AddAsync(It.IsAny<Loan>()), Times.Once);
    }
}
