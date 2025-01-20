using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.QueryModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.HandlerModel.Interfaces;

public interface IHandler
{
    ICommand Handle(Query query);

    IHandler SetNext(IHandler handler);
}