using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Properties;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Interfaces;

public interface ISecurityLevelBuilder
{
    BuilderBase WithSecurityLevel(SecurityLevel securityLevel);
}