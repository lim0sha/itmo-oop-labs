using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Abstractions.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Exceptions.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Models.Entities;
using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Infrastructure.DataAccess.RepositoryModel;
using NSubstitute;
using Xunit;

namespace Lab5.Tests;

public class AtmSystemTests
{
    [Fact]
    public void Scenario1()
    {
        ICrudRepository mockRepository = Substitute.For<ICrudRepository>();
        var user = new User(1, 0001, 1000);
        const int deduceAmount = 1000;
        mockRepository.GetAccount(user.Id).Returns(user);
        var service = new RepositoryMock(mockRepository);

        service.DeduceMoney(user.Id, deduceAmount);

        mockRepository.Received(1).UpdateAccount(Arg.Is<User>(a => a.Balance == 0));
        mockRepository.Received(1).SavePayment(user.Id, "Deduce", deduceAmount);
    }

    [Fact]
    public void Scenario2()
    {
        ICrudRepository mockRepository = Substitute.For<ICrudRepository>();
        var user = new User(2, 0002, 1000);
        const int deduceAmount = 5000;

        mockRepository.GetAccount(user.Id).Returns(user);
        var service = new RepositoryMock(mockRepository);

        Assert.Throws<BalanceException>(() => service.DeduceMoney(user.Id, deduceAmount));
        mockRepository.DidNotReceive().UpdateAccount(Arg.Any<User>());
        mockRepository.DidNotReceive().SavePayment(Arg.Any<int>(), Arg.Any<string>(), Arg.Any<double>());
    }

    [Fact]
    public void Scenario3()
    {
        ICrudRepository mockRepository = Substitute.For<ICrudRepository>();
        var user = new User(3, 0003, 1000);
        const int contributeAmount = 1000;
        mockRepository.GetAccount(user.Id).Returns(user);
        var service = new RepositoryMock(mockRepository);

        service.ContributeMoney(user.Id, contributeAmount);

        mockRepository.Received(1).UpdateAccount(Arg.Is<User>(a => a.Balance == 2000));
        mockRepository.Received(1).SavePayment(user.Id, "Contribute", contributeAmount);
    }
}