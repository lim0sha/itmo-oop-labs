using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.QueryModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.HandlerModel.Handlers;

public class ShowHandler : HandlerBase
{
    private const string Type = "show";
    private string _filePath = string.Empty;
    private string _condition = string.Empty;

    private ICommand Command { get; set; }

    public ShowHandler()
    {
        Command = new ShowCommand("-", "-");
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
        _condition = query.GetFlag(4);
        Command = new ShowCommand(_condition, _filePath);
        return Command;
    }
}