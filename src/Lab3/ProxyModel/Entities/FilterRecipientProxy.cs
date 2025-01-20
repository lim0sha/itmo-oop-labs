using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Properties;
using Itmo.ObjectOrientedProgramming.Lab3.ProxyModel.Helpers;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.ProxyModel.Entities;

public class FilterRecipientProxy : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly SecurityLevel _securityLevel;
    private readonly Checker _checker;

    public string RecipientName { get; init; }

    public FilterRecipientProxy(IRecipient recipient, SecurityLevel securityLevel, string recipientName)
    {
        RecipientName = recipientName;
        _checker = new Checker();
        _securityLevel = securityLevel;
        _recipient = recipient;
    }

    public void GetMessage(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "Message cannot be null");
        }

        if (_checker.CheckAccess(_securityLevel, message))
        {
            _recipient.GetMessage(message);
        }
    }
}