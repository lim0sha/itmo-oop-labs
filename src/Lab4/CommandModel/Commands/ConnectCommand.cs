using Itmo.ObjectOrientedProgramming.Lab4.PathModel.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Commands;

public class ConnectCommand : CommandBase
{
    private string Condition { get; }

    private string Address { get; set; }

    public ConnectCommand(string condition, string address)
    {
        if (string.IsNullOrEmpty(condition))
        {
            throw new ArgumentException("Condition can not be empty", nameof(condition));
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

    protected override void Execute(SystemPath path)
    {
        if (Condition == "local")
        {
            path.UpdateValue(Address);
        }
    }
}