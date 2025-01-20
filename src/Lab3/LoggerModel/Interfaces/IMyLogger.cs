using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.LoggerModel.Interfaces;

public interface IMyLogger
{
    string LoggerName { get; init; }

    void LogMessage(Message message);
}