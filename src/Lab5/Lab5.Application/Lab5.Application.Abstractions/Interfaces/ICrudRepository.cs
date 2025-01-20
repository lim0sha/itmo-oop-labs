using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Models.Entities;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Abstractions.Interfaces;

public interface ICrudRepository
{
    void CreateAccount(User user);

    bool HasAccount(int id);

    User GetAccount(int id);

    void UpdatePin(int id, int? newPin);

    void UpdateAccount(User user);

    void SavePayment(int id, string command, double? amount);

    ReadOnlyCollection<string> GetPaymentList(int id);
}