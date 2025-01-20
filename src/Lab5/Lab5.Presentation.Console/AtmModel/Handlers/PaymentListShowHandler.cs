using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Abstractions.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Models.Entities;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab5.Lab5.Presentation.Console.AtmModel.Handlers;

public class PaymentListShowHandler : BaseHandler
{
    public PaymentListShowHandler(ICrudRepository iCrudRepository) : base(iCrudRepository) { }

    public override void HandleQuery(AtmQuery atmQuery)
    {
        ArgumentNullException.ThrowIfNull(atmQuery);

        if (atmQuery.Command == "ShowPaymentList")
        {
            User user = Database.GetAccount(atmQuery.UserId);

            if (user.Pin == atmQuery.Pin)
            {
                ReadOnlyCollection<string> history = Database.GetPaymentList(atmQuery.UserId);

                if (history.Count == 0)
                {
                    System.Console.WriteLine("No transaction history");
                }
                else
                {
                    System.Console.WriteLine("Transaction history:");
                    foreach (string command in history)
                    {
                        System.Console.WriteLine(command);
                    }
                }
            }
            else
            {
                System.Console.WriteLine("Invalid account number or PIN");
            }
        }
        else
        {
            NextHandler?.HandleQuery(atmQuery);
        }
    }
}