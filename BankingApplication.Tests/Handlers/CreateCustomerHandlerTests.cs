using BankingApplication.Application.Command;
using BankingApplication.Application.Handler;
using BankingApplication.Application.Interfaces;
using BankingApplication.Domain.Entities;
using Moq;

namespace BankingApplication.Tests.Handlers;

public class CreateCustomerHandlerTests
{
    private readonly Mock<IUnitOfWork> _uowMock;
    private readonly Mock<ICustomerRepository> _customerRepoMock;
    private CreateCustomerHandler _handler;

    public CreateCustomerHandlerTests()
    {
        _uowMock = new Mock<IUnitOfWork>();
        _customerRepoMock = new Mock<ICustomerRepository>();

        _uowMock.Setup(x => x.Customer).Returns(_customerRepoMock.Object);
        _handler = new CreateCustomerHandler(_uowMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldAddCustomer()
    {
        var command = new CreateCustomerCommand
        {
            Name = "Vraj",
            Email = "abc.com"
        };

        await _handler.Handle(command, CancellationToken.None);
        _customerRepoMock.Verify(x => x.AddAsync(It.IsAny<Customer>()), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChanges()
    {
        var command = new CreateCustomerCommand
        {
            Name = "Vraj",
            Email = "abc.com"
        };
        await _handler.Handle(command, CancellationToken.None);
        _uowMock.Verify(x => x.SaveChangesAsync(), Times.Once);
    }
}
