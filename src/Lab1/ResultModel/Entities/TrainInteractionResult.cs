namespace Itmo.ObjectOrientedProgramming.Lab1.ResultModel.Entities;

public abstract record TrainInteractionResult
{
    private TrainInteractionResult() { }

    public sealed record Success : TrainInteractionResult;

    public sealed record ExcessiveForceAttachedFailure(double ForceAttached) : TrainInteractionResult;

    public sealed record NonMovableConditionFailure : TrainInteractionResult;

    public sealed record NegativeVelocityConditionFailure : TrainInteractionResult;

    public sealed record StationVelocityLimitFailure(double VelocityLimit) : TrainInteractionResult;

    public sealed record EndStationVelocityLimitFailure(double VelocityLimit) : TrainInteractionResult;
}