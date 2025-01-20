using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Properties;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Builders;

public abstract class BuilderBase : IBuilder, IBodyBuilder, IHeaderBuilder, ISecurityLevelBuilder
{
    private IRenderable? _header;
    private IRenderable? _body;
    private SecurityLevel _securityLevel;

    public Message Build()
    {
        return new Message(_header, _body, _securityLevel);
    }

    public BuilderBase WithHeader(IRenderable header)
    {
        _header = header;
        return this;
    }

    public BuilderBase WithBody(IRenderable body)
    {
        _body = body;
        return this;
    }

    public BuilderBase WithSecurityLevel(SecurityLevel securityLevel)
    {
        _securityLevel = securityLevel;
        return this;
    }

    public abstract Message Create(IRenderable header, IRenderable body, SecurityLevel securityLevel);
}