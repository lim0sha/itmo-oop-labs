using Itmo.ObjectOrientedProgramming.Lab3.LoggerModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.LoggerModel.Entities;

public class MyLogger : IMyLogger
{
    public string LoggerName { get; init; }

    public void LogMessage(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "Message cannot be null");
        }

        Console.WriteLine(message.Render());
    }

    public MyLogger(string loggerName)
    {
        if (string.IsNullOrEmpty(loggerName))
        {
            throw new ArgumentOutOfRangeException(nameof(loggerName), "Name cannot be empty");
        }

        LoggerName = loggerName;
    }
}