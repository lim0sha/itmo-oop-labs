using Itmo.ObjectOrientedProgramming.Lab4.PathModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.PathModel.Path;

public class SystemPath : IUpdater
{
    public string Context { get; private set; }

    public SystemPath(string context)
    {
        Context = context;
    }

    public void UpdateValue(string newContext)
    {
        Context = newContext;
    }
}