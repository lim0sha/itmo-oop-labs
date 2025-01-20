using Itmo.ObjectOrientedProgramming.Lab3.DisplayModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.RecipientModel.Entities;

public class RecipientDisplay : IRecipient
{
    public string RecipientName { get; init; }

    private DisplayDriverDriver DisplayDriverDriver { get; init; }

    public RecipientDisplay(string displayName)
    {
        if (string.IsNullOrEmpty(displayName))
        {
            throw new ArgumentOutOfRangeException(nameof(displayName), "Display name cannot be empty");
        }

        RecipientName = displayName;
        DisplayDriverDriver = new DisplayDriverDriver(RecipientName);
    }

    public void GetMessage(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "Message cannot be null");
        }

        DisplayDriverDriver.GetMessage(message);
    }
}