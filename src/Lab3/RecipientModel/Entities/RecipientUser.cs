using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.UserModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.RecipientModel.Entities;

public class RecipientUser : IRecipient
{
    public User User { get; init; }

    public string RecipientName { get; init; }

    public RecipientUser(string recipientName, int id, User user)
    {
        if (string.IsNullOrEmpty(recipientName))
        {
            throw new ArgumentOutOfRangeException(nameof(recipientName), "Name cannot be empty");
        }

        if (id < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Id cannot be negative");
        }

        RecipientName = recipientName;
        User = user;
    }

    public void GetMessage(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "Message cannot be null");
        }

        User.GetMessage(message);
    }
}