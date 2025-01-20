using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.HandlerModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.QueryModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.HandlerModel.Handlers;

public abstract class BaseHandler : IHandler
{
    public ICommand Handle(Query query)
    {
        throw new NotImplementedException();
    }

    public IHandler SetNext(IHandler handler)
    {
        throw new NotImplementedException();
    }
}