using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.QueryModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.HandlerModel.Handlers;

public class MoveHandler : HandlerBase
{
    private const string Type = "move";
    private string _initialPath = string.Empty;
    private string _finitePath = string.Empty;

    private ICommand Command { get; set; }

    public MoveHandler()
    {
        Command = new MoveCommand("-", "-");
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

        _initialPath = query.GetFlag(2);
        _finitePath = query.GetFlag(3);
        Command = new CopyCommand(_initialPath, _finitePath);
        return Command;
    }
}