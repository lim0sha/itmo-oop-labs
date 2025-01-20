using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Abstractions.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Models.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab5.Lab5.Presentation.Console.AtmModel.Handlers;

public class PinUpdateHandler : BaseHandler
{
    public PinUpdateHandler(ICrudRepository iCrudRepository) : base(iCrudRepository) { }

    public override void HandleQuery(AtmQuery atmQuery)
    {
        ArgumentNullException.ThrowIfNull(atmQuery);

        if (atmQuery.Command == "UpdatePIN")
        {
            int userId = atmQuery.UserId;
            int? newPin = atmQuery.UpdatedPin;

            if (Database.HasAccount(userId))
            {
                Database.UpdatePin(userId, newPin);
                System.Console.WriteLine("Pin changed successfully");
            }
            else
            {
                System.Console.WriteLine($"Account with id {userId} not found");
            }
        }
        else
        {
            NextHandler?.HandleQuery(atmQuery);
        }
    }
}