using Itmo.ObjectOrientedProgramming.Lab3.LoggerModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.RecipientModel.Decorators;

public class LoggerDecorator : ILoggerDecorator
{
    private readonly IRecipient _recipient;
    private readonly IMyLogger _myLogger;

    public string RecipientName => _recipient.RecipientName;

    public LoggerDecorator(IMyLogger myLogger, IRecipient recipient)
    {
        _recipient = recipient ?? throw new ArgumentNullException(nameof(recipient), "Recipient cannot be null");
        _myLogger = myLogger ?? throw new ArgumentNullException(nameof(myLogger), "Logger cannot be null");
    }

    public void GetMessage(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "Message cannot be null");
        }

        _recipient.GetMessage(message);
        _myLogger.LogMessage(message);
    }
}