using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Properties;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Builders;

public class DefaultBuilder : BuilderBase
{
    public override Message Create(IRenderable header, IRenderable body, SecurityLevel securityLevel)
    {
        return new Message(header, body, securityLevel);
    }
}