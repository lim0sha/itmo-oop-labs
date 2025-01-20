namespace Itmo.ObjectOrientedProgramming.Lab3.ResultModel.Entities;

public abstract record MessageInteractionResult
{
    private MessageInteractionResult() { }

    public sealed record MessageIsSent : MessageInteractionResult;

    public sealed record MessageIsNotSent : MessageInteractionResult;

    public sealed record MessageStateChanged : MessageInteractionResult;

    public sealed record MessageStateIsNotChanged : MessageInteractionResult;
}