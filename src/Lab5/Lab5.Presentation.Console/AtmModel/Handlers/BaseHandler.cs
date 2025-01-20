using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Abstractions.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Models.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab5.Lab5.Presentation.Console.AtmModel.Handlers;

public abstract class BaseHandler
{
    protected BaseHandler(ICrudRepository database)
    {
        Database = database ?? throw new ArgumentNullException(nameof(database), "DB can not be null");
    }

    public BaseHandler SetNextHandler(BaseHandler? nextHandler)
    {
        NextHandler = nextHandler;
        return this;
    }

    protected BaseHandler? NextHandler { get; private set; }

    protected ICrudRepository Database { get; private set; }

    public abstract void HandleQuery(AtmQuery atmQuery);
}