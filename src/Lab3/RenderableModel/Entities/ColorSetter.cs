using Itmo.ObjectOrientedProgramming.Lab3.RenderableModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.RenderableModel.Entities;

public class ColorSetter : IModifier
{
    private readonly ConsoleColor _color;

    public ColorSetter(ConsoleColor color)
    {
        _color = color;
    }

    public string Modify(string? text)
    {
        if (text == null)
        {
            throw new ArgumentNullException(nameof(text), "Message cannot be null");
        }

        Console.ForegroundColor = _color;
        Console.WriteLine(text);
        Console.ResetColor();
        return text;
    }
}