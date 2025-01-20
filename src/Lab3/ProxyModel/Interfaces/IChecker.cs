using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Properties;

namespace Itmo.ObjectOrientedProgramming.Lab3.ProxyModel.Interfaces;

public interface IChecker
{
    bool CheckAccess(SecurityLevel securityLevel, Message message);
}