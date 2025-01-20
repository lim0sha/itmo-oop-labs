using Itmo.ObjectOrientedProgramming.Lab1.ResultModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.TrainModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.RoutePartsModel.Entities;

public class EndStationRoutePart : RoutePartBase
{
    private double VelocityLimit { get; }

    public EndStationRoutePart(double distance, double velocityLimit)
    {
        if (distance <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(distance), "Distance must be greater than zero.");
        }

        if (velocityLimit <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(velocityLimit), "Velocity limit must be greater than zero.");
        }

        Distance = distance;
        VelocityLimit = velocityLimit;
    }

    public override TrainInteractionResult ContextPass(Train train)
    {
        if (train == null)
        {
            throw new ArgumentNullException(nameof(train), "Object cannot be null.");
        }

        if (train.ResultVelocity > VelocityLimit)
        {
            return new TrainInteractionResult.EndStationVelocityLimitFailure(VelocityLimit);
        }

        return CommonPass(train);
    }

    public override void Affect(Train train)
    {
        if (train == null)
        {
            throw new ArgumentNullException(nameof(train), "Object cannot be null.");
        }

        if (ContextPass(train) is TrainInteractionResult.Success)
        {
            train.CalculateTerminalState();
        }
    }

    public override double ComputePassageTime(Train train)
    {
        if (train == null)
        {
            throw new ArgumentNullException(nameof(train), "Object cannot be null.");
        }

        return 2 * Distance / train.ResultVelocity;
    }
}