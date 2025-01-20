using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Helpers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.QueryModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.VisitorModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.VisitorModel.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.HandlerModel.Handlers;

public class TreeListHandler : HandlerBase
{
    private const string Type = "list";
    private readonly IVisitor _visitor;
    private readonly IPathBuilder _pathBuilder;
    private string _treeDepth = string.Empty;

    private ICommand Command { get; set; }

    public TreeListHandler()
    {
        _visitor = new Visitor();
        _pathBuilder = new PathBuilder();
        Command = new TreeListCommand("0", _visitor, _pathBuilder);
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

        _treeDepth = query.GetFlag(3);
        Command = new TreeListCommand(_treeDepth, _visitor, _pathBuilder);
        return Command;
    }
}