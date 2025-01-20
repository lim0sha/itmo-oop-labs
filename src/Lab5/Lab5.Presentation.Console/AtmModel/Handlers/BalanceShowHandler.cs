using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Abstractions.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Models.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab5.Lab5.Presentation.Console.AtmModel.Handlers;

public class BalanceShowHandler : BaseHandler
{
    public BalanceShowHandler(ICrudRepository iCrudRepository) : base(iCrudRepository) { }

    public override void HandleQuery(AtmQuery atmQuery)
    {
        ArgumentNullException.ThrowIfNull(atmQuery);

        if (atmQuery.Command == "ShowBalance")
        {
            User user = Database.GetAccount(atmQuery.UserId);

            System.Console.WriteLine(user.Pin == atmQuery.Pin
                ? $"Account balance: {user.Balance}"
                : "Invalid account number or PIN");
        }
        else
        {
            NextHandler?.HandleQuery(atmQuery);
        }
    }
}