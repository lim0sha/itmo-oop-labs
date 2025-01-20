using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Properties;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientModel.Decorators;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.ResultModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.UserModel.Interfaces;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.UserModel.Entities;

public class User : IUser
{
    private readonly Collection<Message> _messages;

    public Collection<Collection<Message>> States { get; }

    public string Username { get; init; }

    public int Id { get; init; }

    public User(string username, int id)
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentOutOfRangeException(nameof(username), "Username name cannot be empty");
        }

        if (id < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Id cannot be negative");
        }

        Username = username;
        Id = id;
        _messages = [];
        States = [[], [], []];
    }

    public void GetMessage(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "Message cannot be null");
        }

        _messages.Add(message);
        if (!States[(int)ReadingState.Unread].Contains(message))
        {
            States[(int)ReadingState.Unread].Add(message);
        }
    }

    public MessageInteractionResult UpdateMessageState(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "Message cannot be null");
        }

        if (!States[(int)ReadingState.Unread].Remove(message))
        {
            return new MessageInteractionResult.MessageStateIsNotChanged();
        }

        States[(int)ReadingState.Read].Add(message);
        return new MessageInteractionResult.MessageStateChanged();
    }

    public MessageInteractionResult UpdateAllMessagesStates()
    {
        bool stateChanged = false;

        foreach (Message? message in _messages.Where(message => States[(int)ReadingState.Unread].Remove(message)))
        {
            States[(int)ReadingState.Read].Add(message);
            stateChanged = true;
        }

        return stateChanged
            ? new MessageInteractionResult.MessageStateChanged()
            : new MessageInteractionResult.MessageStateIsNotChanged();
    }

    public void Send(IRecipient recipient, Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "Message cannot be null");
        }

        recipient.GetMessage(message);
    }

    public void Send(LoggerDecorator loggerRecipient, Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "Message cannot be null");
        }

        loggerRecipient.GetMessage(message);
    }
}