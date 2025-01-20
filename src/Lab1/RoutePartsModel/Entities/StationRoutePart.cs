using Itmo.ObjectOrientedProgramming.Lab1.ResultModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.TrainModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.RoutePartsModel.Entities;

public class StationRoutePart : RoutePartBase
{
    private double VelocityLimit { get; }

    private double BoardingTime { get; }

    public StationRoutePart(double distance, double velocityLimit, double boardingTime)
    {
        if (distance <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(distance), "Distance must be greater than zero.");
        }

        if (velocityLimit <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(velocityLimit), "Velocity limit must be greater than zero.");
        }

        if (boardingTime < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(boardingTime), "Boarding time cannot be negative.");
        }

        Distance = distance;
        VelocityLimit = velocityLimit;
        BoardingTime = boardingTime;
    }

    public override TrainInteractionResult ContextPass(Train train)
    {
        if (train == null)
        {
            throw new ArgumentNullException(nameof(train), "Object cannot be null.");
        }

        if (train.ResultVelocity > VelocityLimit)
        {
            return new TrainInteractionResult.StationVelocityLimitFailure(VelocityLimit);
        }

        return CommonPass(train);
    }

    public override void Affect(Train train)
    {
        if (train == null)
        {
            throw new ArgumentNullException(nameof(train), "Object cannot be null.");
        }

        train.CalculateResultVelocity();
    }

    public override double ComputePassageTime(Train train)
    {
        if (train == null)
        {
            throw new ArgumentNullException(nameof(train), "Object cannot be null.");
        }

        // train slows down to the middle of the station and accelerates the remaining half of it
        return (2 * Distance / train.ResultVelocity) + BoardingTime;
    }
}