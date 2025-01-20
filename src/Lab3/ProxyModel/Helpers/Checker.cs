using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Properties;
using Itmo.ObjectOrientedProgramming.Lab3.ProxyModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.ProxyModel.Helpers;

public class Checker : IChecker
{
    public bool CheckAccess(SecurityLevel securityLevel, Message message)
    {
        return message == null
            ? throw new ArgumentNullException(nameof(message), "Message cannot be null")
            : securityLevel <= message.SecurityLevel;
    }
}