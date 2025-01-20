using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Abstractions.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Models.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab5.Lab5.Presentation.Console.AtmModel.Handlers;

public class UserCreationHandler : BaseHandler
{
    private const double DefaultBalance = 0;

    public UserCreationHandler(ICrudRepository iCrudRepository) : base(iCrudRepository) { }

    public override void HandleQuery(AtmQuery atmQuery)
    {
        ArgumentNullException.ThrowIfNull(atmQuery);

        if (atmQuery.Command == "CreateAccount")
        {
            var user = new User(atmQuery.UserId, atmQuery.Pin, DefaultBalance);
            Database.CreateAccount(user);
            System.Console.WriteLine("Account creation was done correct");
        }
        else
        {
            NextHandler?.HandleQuery(atmQuery);
        }
    }
}