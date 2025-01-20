using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Properties;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Builders;

public class ColorBuilder : BuilderBase, IApplier
{
    private readonly ConsoleColor _color;

    public Modifier ApplyModifier(IRenderable renderable, IModifier modifier)
    {
        return new Modifier(renderable, modifier);
    }

    public ColorBuilder(ConsoleColor color)
    {
        _color = color;
    }

    public override Message Create(IRenderable header, IRenderable body, SecurityLevel securityLevel)
    {
        return new Message(header, ApplyModifier(body, new ColorSetter(_color)), securityLevel);
    }
}