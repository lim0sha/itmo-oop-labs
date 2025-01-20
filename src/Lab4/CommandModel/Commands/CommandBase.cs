using Itmo.ObjectOrientedProgramming.Lab4.PathModel.Path;
using ICommand = Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Interfaces.ICommand;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Commands;

public abstract class CommandBase : ICommand
{
    public abstract IList<string> GetParams();

    public void CanExecute(SystemPath path)
    {
        if (path == null)
        {
            throw new ArgumentNullException(nameof(path), "Path can not be null");
        }

        if (string.IsNullOrEmpty(path.Context))
        {
            throw new ArgumentException("Path can not be empty.", nameof(path));
        }

        Execute(path);
    }

    protected abstract void Execute(SystemPath path);
}