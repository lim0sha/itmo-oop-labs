using Itmo.ObjectOrientedProgramming.Lab4.PathModel.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Commands;

public class RenameCommand : CommandBase
{
    private string Address { get; }

    private string NewName { get; }

    public RenameCommand(string address, string newName)
    {
        if (string.IsNullOrEmpty(address))
        {
            throw new ArgumentException("Address can not be empty", nameof(address));
        }

        if (string.IsNullOrEmpty(newName))
        {
            throw new ArgumentException("Name path can not be empty", nameof(newName));
        }

        Address = address;
        NewName = newName;
    }

    public override IList<string> GetParams()
    {
        IList<string> list = [];
        list.Add(Address);
        list.Add(NewName);
        return list;
    }

    protected override void Execute(SystemPath path)
    {
        string initialPath = path.Context.TrimEnd('\\') + "\\" + Address;
        string finitePath = path.Context.TrimEnd('\\') + "\\" + NewName;

        if (!File.Exists(initialPath))
        {
            throw new FileNotFoundException($"Source file not found: {initialPath}");
        }

        if (File.Exists(finitePath))
        {
            throw new IOException($"Destination file already exists: {finitePath}");
        }

        using var from = new FileStream(initialPath, FileMode.Open, FileAccess.Read);
        using var to = new FileStream(finitePath, FileMode.Create, FileAccess.Write);

        from.CopyTo(to);

        if (File.Exists(initialPath))
        {
            File.Delete(initialPath);
        }
    }
}