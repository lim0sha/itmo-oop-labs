using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.QueryModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.HandlerModel.Handlers;

public class ConnectHandler : HandlerBase
{
    private const string Type = "connect";
    private string _filePath = string.Empty;
    private string _condition = string.Empty;

    private ICommand Command { get; set; }

    public ConnectHandler()
    {
        Command = new ConnectCommand("-", "-");
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

        _filePath = query.GetFlag(1);
        _condition = query.GetFlag(3);
        Command = new ConnectCommand(_filePath, _condition);
        return Command;
    }
}