using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.PathModel.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Commands;

public class ShowCommand : CommandBase, IPrintable
{
    private string Condition { get; }

    private string Address { get; }

    public ShowCommand(string condition, string address)
    {
        if (string.IsNullOrEmpty(condition))
        {
            throw new ArgumentException("Condition can npt be empty", nameof(condition));
        }

        if (string.IsNullOrEmpty(address))
        {
            throw new ArgumentException("Address can not be empty", nameof(address));
        }

        Condition = condition;
        Address = address;
    }

    public override IList<string> GetParams()
    {
        IList<string> list = [];
        list.Add(Address);
        list.Add(Condition);
        return list;
    }

    public void Print(string path)
    {
        Console.WriteLine("File data: " + path + " \nFile has a " + Condition + " state");
    }

    protected override void Execute(SystemPath path)
    {
        if (path == null)
        {
            throw new ArgumentNullException(nameof(path), "Path can not be null");
        }

        if (string.IsNullOrEmpty(path.Context))
        {
            throw new ArgumentException("Path can not be empty.", nameof(path));
        }

        string thePath = path.Context.TrimEnd('\\') + "\\" + Address;
        Print(thePath);
    }
}