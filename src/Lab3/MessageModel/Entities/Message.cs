using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Properties;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Entities;

public class Message : IRenderable
{
    public IRenderable Header { get; init; }

    public IRenderable Body { get; init; }

    public SecurityLevel SecurityLevel { get; init; }

    public Message(IRenderable? header, IRenderable? body, SecurityLevel securityLevel)
    {
        SecurityLevel = securityLevel;
        Header = header ?? throw new ArgumentNullException(nameof(header), "Header cannot be null");
        Body = body ?? throw new ArgumentNullException(nameof(body), "Body cannot be null");
    }

    public string Render()
    {
        return Header.Render() + " " + Body.Render();
    }
}