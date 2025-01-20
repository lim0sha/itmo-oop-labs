using Itmo.ObjectOrientedProgramming.Lab4.PathModel.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Commands;

public class DeleteCommand : CommandBase
{
    private string Address { get; }

    public DeleteCommand(string address)
    {
        if (string.IsNullOrEmpty(address))
        {
            throw new ArgumentException("Address can not be empty", nameof(address));
        }

        Address = address;
    }

    public override IList<string> GetParams()
    {
        IList<string> list = [];
        list.Add(Address);
        return list;
    }

    protected override void Execute(SystemPath path)
    {
        string newPath = path.Context.TrimEnd('\\') + "\\" + Address;
        File.Delete(newPath);
    }
}