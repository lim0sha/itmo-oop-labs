using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Abstractions.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Models.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab5.Lab5.Presentation.Console.AtmModel.Handlers;

public class ContributionHandler : BaseHandler
{
    public ContributionHandler(ICrudRepository iCrudRepository) : base(iCrudRepository) { }

    public override void HandleQuery(AtmQuery atmQuery)
    {
        ArgumentNullException.ThrowIfNull(atmQuery);

        if (atmQuery.Command == "Contribute")
        {
            User user = Database.GetAccount(atmQuery.UserId);

            if (user.Pin == atmQuery.Pin)
            {
                var updatedAccount = new User(user.Id, user.Pin, user.Balance + atmQuery.PaymentAmount);

                Database.UpdateAccount(updatedAccount);
                System.Console.WriteLine("Contributing money was done correct");
            }

            Database.SavePayment(atmQuery.UserId, "Contribute", atmQuery.PaymentAmount);

            Database.CreateAccount(user);
        }
        else
        {
            NextHandler?.HandleQuery(atmQuery);
        }
    }
}