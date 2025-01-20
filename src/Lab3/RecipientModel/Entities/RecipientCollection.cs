using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.RecipientModel.Entities;

public class RecipientCollection : IRecipient
{
    private readonly List<IRecipient> _recipients;

    public string RecipientName { get; init; }

    public RecipientCollection(string recipientName)
    {
        if (string.IsNullOrEmpty(recipientName))
        {
            throw new ArgumentOutOfRangeException(nameof(recipientName), "Name cannot be empty");
        }

        RecipientName = recipientName;
        _recipients = [];
    }

    public void GetMessage(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "Message cannot be null");
        }

        foreach (IRecipient recipient in _recipients)
        {
            recipient.GetMessage(message);
        }
    }
}