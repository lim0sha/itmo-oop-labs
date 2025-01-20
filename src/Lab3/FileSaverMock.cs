using Itmo.ObjectOrientedProgramming.Lab3.RenderableModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class FileSaverMock
{
    private readonly string _filePath;

    public FileSaverMock(string filePath)
    {
        _filePath = filePath;
    }

    public void SaveMessageToFile(IRenderable message, bool isColored = false, ConsoleColor color = ConsoleColor.White)
    {
        string renderedMessage = message.Render();
        using var writer = new StreamWriter(_filePath, true);
        if (isColored)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(renderedMessage);
            writer.WriteLine($"[Colored: {color}] {renderedMessage}");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine(renderedMessage);
            writer.WriteLine(renderedMessage);
        }
    }
}