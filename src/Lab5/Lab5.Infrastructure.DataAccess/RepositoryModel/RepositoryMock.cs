using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Abstractions.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Exceptions.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Models.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab5.Lab5.Infrastructure.DataAccess.RepositoryModel;

public class RepositoryMock
{
    private readonly ICrudRepository _iCrudRepository;

    public RepositoryMock(ICrudRepository iCrudRepository)
    {
        _iCrudRepository = iCrudRepository;
    }

    public void DeduceMoney(int userId, double amount)
    {
        ArgumentNullException.ThrowIfNull(userId);
        ArgumentNullException.ThrowIfNull(amount);

        User account = _iCrudRepository.GetAccount(userId);
        if (account == null || account.Balance < amount)
        {
            throw new BalanceException();
        }

        var newUser = new User(account.Id, account.Pin, account.Balance - amount);

        _iCrudRepository.UpdateAccount(newUser);
        _iCrudRepository.SavePayment(userId, "Deduce", amount);
    }

    public void ContributeMoney(int userId, double amount)
    {
        User user = _iCrudRepository.GetAccount(userId);
        var newUser = new User(user.Id, user.Pin, user.Balance + amount);

        _iCrudRepository.UpdateAccount(newUser);
        _iCrudRepository.SavePayment(userId, "Contribute", amount);
    }
}
