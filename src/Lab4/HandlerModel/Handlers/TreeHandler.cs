using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.HandlerModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.QueryModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.HandlerModel.Handlers;

public class TreeHandler : HandlerBase
{
    private const string Type = "tree";

    private IHandler NextTreeHandler { get; set; }

    public TreeHandler()
    {
        NextTreeHandler = new TreeGoToHandler().SetNext(new TreeListHandler());
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

        return NextTreeHandler.Handle(query);
    }
}