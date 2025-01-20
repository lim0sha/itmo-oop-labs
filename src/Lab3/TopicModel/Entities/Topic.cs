using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.TopicModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.UserModel.Interfaces;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.TopicModel.Entities;

public class Topic : IGetSender
{
    private readonly Collection<Message> _messages;

    public string Name { get; init; }

    public Topic(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Title cannot be empty");
        }

        Name = name;
        _messages = [];
    }

    public void Send(IGetter recipient, Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "Message cannot be null");
        }

        recipient.GetMessage(message);
        _messages.Add(message);
    }
}