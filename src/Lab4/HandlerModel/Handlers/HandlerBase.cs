using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.HandlerModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.QueryModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.HandlerModel.Handlers;

public abstract class HandlerBase : IHandler
{
    protected IHandler? Next { get; private set; }

    public abstract ICommand Handle(Query query);

    public IHandler SetNext(IHandler handler)
    {
        if (Next == null)
        {
            Next = handler;
        }
        else
        {
            Next.SetNext(handler);
        }

        return this;
    }
}