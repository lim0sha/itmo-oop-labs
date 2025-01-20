using Itmo.ObjectOrientedProgramming.Lab3.DisplayModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayModel.Entities;

public class DisplayDriverDriver : IDrawer, IDisplayDriver, IRecipient
{
    private Message? _message;

    public string RecipientName { get; init; }

    public DisplayDriverDriver(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Display name cannot be empty");
        }

        RecipientName = name;
    }

    public void GetMessage(Message message)
    {
        _message = message ?? throw new ArgumentNullException(nameof(message), "Message cannot be null");
    }

    public void PostColorMessage(ConsoleColor color)
    {
        if (_message != null)
        {
            _message = new ColorBuilder(color).Create(_message.Header, _message.Body, _message.SecurityLevel);
        }
    }

    public void ConsoleDraw()
    {
        if (_message != null)
        {
            Console.WriteLine(_message.Render());
        }
    }
}