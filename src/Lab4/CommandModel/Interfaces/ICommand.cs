using Itmo.ObjectOrientedProgramming.Lab4.PathModel.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Interfaces;

public interface ICommand
{
    IList<string> GetParams();

    void CanExecute(SystemPath path);
}