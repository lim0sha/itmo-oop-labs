using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.PathModel.Path;
using System.Diagnostics;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Decorators;

public class CommandDecorator
{
    private readonly ICommand _command;

    public TimeSpan ExecutionTime { get; private set; }

    public CommandDecorator(ICommand command)
    {
        _command = command ?? throw new ArgumentNullException(nameof(command), "Command can not be null");
        ExecutionTime = TimeSpan.Zero;
    }

    public IList<string> GetParams()
    {
        return _command.GetParams();
    }

    public void CanExecute(SystemPath path)
    {
        var timer = new Stopwatch();
        timer.Start();
        _command.CanExecute(path);
        timer.Stop();
        ExecutionTime = timer.Elapsed;
    }
}