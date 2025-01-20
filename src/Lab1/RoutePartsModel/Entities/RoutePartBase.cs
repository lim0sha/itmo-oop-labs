using Itmo.ObjectOrientedProgramming.Lab1.ResultModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.RoutePartsModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.TrainModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.RoutePartsModel.Entities;

public abstract class RoutePartBase : IRoutePart
{
    public double Distance { get; init; }

    public TrainInteractionResult CommonPass(Train train)
    {
        if (train == null)
        {
            throw new ArgumentNullException(nameof(train), "Object cannot be null.");
        }

        if (train is { ResultVelocity: 0, Acceleration: 0, IsTerminalState: false })
        {
            return new TrainInteractionResult.NonMovableConditionFailure();
        }

        if (train.ResultVelocity < 0)
        {
            return new TrainInteractionResult.NegativeVelocityConditionFailure();
        }

        return new TrainInteractionResult.Success();
    }

    public abstract TrainInteractionResult ContextPass(Train train);

    public abstract void Affect(Train train);

    public abstract double ComputePassageTime(Train train);
}