using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Abstractions.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Models.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab5.Lab5.Presentation.Console.AtmModel.Handlers;

public class DeduceHandler : BaseHandler
{
    public DeduceHandler(ICrudRepository iCrudRepository) : base(iCrudRepository) { }

    public override void HandleQuery(AtmQuery atmQuery)
    {
        ArgumentNullException.ThrowIfNull(atmQuery);

        if (atmQuery.Command == "Deduce")
        {
            User user = Database.GetAccount(atmQuery.UserId);

            if (user.Pin != atmQuery.Pin)
            {
                System.Console.WriteLine("Wrong PIN");
                return;
            }

            if (user.Balance < atmQuery.PaymentAmount)
            {
                System.Console.WriteLine("Insufficient funds");
            }
            else
            {
                var updatedAccount = new User(user.Id, user.Pin, user.Balance - atmQuery.PaymentAmount);
                Database.UpdateAccount(updatedAccount);
                Database.SavePayment(atmQuery.UserId, "Deduce", atmQuery.PaymentAmount);
                System.Console.WriteLine("Deducing money was done correct");
                System.Console.WriteLine($"$New balance {updatedAccount.Balance}");
            }
        }
        else
        {
            NextHandler?.HandleQuery(atmQuery);
        }
    }
}