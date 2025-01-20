using Itmo.ObjectOrientedProgramming.Lab4.PathModel.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Commands;

public class DisconnectCommand : CommandBase
{
    private string Address { get; }

    public DisconnectCommand(string address)
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
        path.UpdateValue(Address);
    }
}