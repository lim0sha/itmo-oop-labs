using Itmo.ObjectOrientedProgramming.Lab4.PathModel.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Commands;

public class CopyCommand : CommandBase
{
    private string InitialPath { get; }

    private string FinitePath { get; }

    public CopyCommand(string initialPath, string finitePath)
    {
        if (string.IsNullOrEmpty(initialPath))
        {
            throw new ArgumentException("Initial path can not be empty", nameof(initialPath));
        }

        if (string.IsNullOrEmpty(finitePath))
        {
            throw new ArgumentException("Finite path can not be empty", nameof(finitePath));
        }

        InitialPath = initialPath;
        FinitePath = finitePath;
    }

    public override IList<string> GetParams()
    {
        IList<string> list = [];
        list.Add(InitialPath);
        list.Add(FinitePath);
        return list;
    }

    protected override void Execute(SystemPath path)
    {
        string initialPath = path.Context.TrimEnd('\\') + "\\" + InitialPath;
        string finitePath = path.Context.TrimEnd('\\') + "\\" + FinitePath;
        using var sourceStream = new FileStream(initialPath, FileMode.Open, FileAccess.Read);
        using var destinationStream = new FileStream(finitePath, FileMode.Create, FileAccess.Write);
        sourceStream.CopyTo(destinationStream);
    }
}