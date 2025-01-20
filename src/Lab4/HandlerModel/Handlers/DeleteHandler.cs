using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.QueryModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.HandlerModel.Handlers;

public class DeleteHandler : HandlerBase
{
    private const string Type = "delete";

    private ICommand Command { get; set; }

    public DeleteHandler()
    {
        Command = new DeleteCommand("-");
    }

    public override ICommand Handle(Query query)
    {
        if (query == null)
        {
            throw new ArgumentNullException(nameof(query), "Query can not be null");
        }

        if (query.GetFlag(1) != Type)
        {
            if (Next != null) return Next.Handle(query);
        }

        return Command;
    }
}