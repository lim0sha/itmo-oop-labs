using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.MessengerModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.RecipientModel.Entities;

public class RecipientMessenger : IRecipient
{
    public string RecipientName { get; init; }

    private readonly IMessenger _messenger;

    public RecipientMessenger(string recipientName, IMessenger messenger)
    {
        if (string.IsNullOrEmpty(recipientName))
        {
            throw new ArgumentOutOfRangeException(nameof(recipientName), "User name cannot be empty");
        }

        RecipientName = recipientName;
        _messenger = messenger;
    }

    public void GetMessage(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "Message cannot be null");
        }

        _messenger.GetMessage(message);
    }
}