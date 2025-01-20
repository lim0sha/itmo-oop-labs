using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.QueryModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.HandlerModel.Handlers;

public class TreeGoToHandler : HandlerBase
{
    private const string Type = "goto";
    private string _filePath = string.Empty;

    private ICommand Command { get; set; }

    public TreeGoToHandler()
    {
        Command = new TreeGoToCommand("-");
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

        _filePath = query.GetFlag(2);
        Command = new TreeGoToCommand(_filePath);
        return Command;
    }
}