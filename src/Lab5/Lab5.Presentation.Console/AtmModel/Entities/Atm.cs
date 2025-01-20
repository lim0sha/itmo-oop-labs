using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Abstractions.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Models.Entities;
using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Presentation.Console.AtmModel.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab5.Lab5.Presentation.Console.AtmModel.Entities;

public class Atm
{
    private readonly BaseHandler _operationHandler;

    public Atm(ICrudRepository database)
    {
        _operationHandler = InitializeHandlers(database);
    }

    public static BaseHandler InitializeHandlers(ICrudRepository database)
    {
        var createAccountHandler = new UserCreationHandler(database);
        var viewBalanceHandler = new BalanceShowHandler(database);
        var withdrawHandler = new DeduceHandler(database);
        var depositHandler = new ContributionHandler(database);
        var viewHistoryHandler = new PaymentListShowHandler(database);
        var changePasswordHandler = new PinUpdateHandler(database);

        createAccountHandler.SetNextHandler(viewBalanceHandler);
        viewBalanceHandler.SetNextHandler(withdrawHandler);
        withdrawHandler.SetNextHandler(depositHandler);
        depositHandler.SetNextHandler(viewHistoryHandler);
        viewHistoryHandler.SetNextHandler(changePasswordHandler);

        return createAccountHandler;
    }

    public void ProcessRequest(AtmQuery query)
    {
        _operationHandler.HandleQuery(query);
    }
}