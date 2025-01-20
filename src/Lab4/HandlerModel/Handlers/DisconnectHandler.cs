using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.QueryModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.HandlerModel.Handlers;

public class DisconnectHandler : HandlerBase
{
    private const string Type = "disconnect";

    private ICommand Command { get; set; }

    public DisconnectHandler()
    {
        Command = new DisconnectCommand("-");
    }

    public override ICommand Handle(Query query)
    {
        if (query == null)
        {
            throw new ArgumentNullException(nameof(query), "Query can not be null");
        }

        if (query.GetFlag(0) != Type)
        {
            if (Next != null) return Next.Handle(query);
        }

        return Command;
    }
}