using Itmo.ObjectOrientedProgramming.Lab3.RenderableModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.RenderableModel.Entities;

public class Modifier : IRenderable
{
    private readonly IRenderable _renderable;
    private readonly IModifier _modifier;

    public Modifier(IRenderable renderable, IModifier modifier)
    {
        _modifier = modifier;
        _renderable = renderable;
    }

    public string Render()
    {
        return _modifier.Modify(_renderable.Render() ?? throw new ArgumentNullException());
    }
}