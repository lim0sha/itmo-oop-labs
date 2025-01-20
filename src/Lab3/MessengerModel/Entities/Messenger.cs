using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.MessengerModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessengerModel.Entities;

public class Messenger : IMessenger
{
    private readonly List<Message> _messages;

    public string MessengerName { get; init; }

    public Messenger(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be empty");
        }

        MessengerName = name;
        _messages = [];
    }

    public void GetMessage(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "Message cannot be null");
        }

        _messages.Add(message);
    }

    public void ConsoleDraw()
    {
        if (_messages.Count > 0)
        {
            Message message = _messages[0];
            _messages.RemoveAt(0);
            Console.WriteLine(message.Render());
        }
        else
        {
            Console.WriteLine("No messages to display.");
        }
    }
}