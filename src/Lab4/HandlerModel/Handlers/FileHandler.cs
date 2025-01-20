using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.HandlerModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.QueryModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.HandlerModel.Handlers;

public class FileHandler : HandlerBase
{
    private const string Type = "file";

    private IHandler NextFileHandler { get; set; }

    public FileHandler()
    {
        NextFileHandler = new ShowHandler().SetNext(
            new CopyHandler().SetNext(
                new DeleteHandler().SetNext(
                    new MoveHandler())));
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

        return NextFileHandler.Handle(query);
    }
}