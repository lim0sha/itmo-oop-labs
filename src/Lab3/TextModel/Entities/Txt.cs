using Itmo.ObjectOrientedProgramming.Lab3.RenderableModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.TextModel.Interfaces;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.TextModel.Entities;

public class Txt : ITxt<Txt>
{
    private readonly Collection<IModifier> _modifiers;

    private string TextContent { get; init; }

    public Txt(string textContent)
    {
        TextContent = textContent ?? throw new ArgumentNullException(nameof(textContent), "Content cannot be null");
        _modifiers = [];
    }

    public string Render()
    {
        return _modifiers.Aggregate(TextContent, (content, modifier) => modifier.Modify(content) ?? throw new ArgumentException());
    }

    public Txt AddModifier(IModifier modifier)
    {
        _modifiers.Add(modifier);
        return this;
    }
}