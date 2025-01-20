using Itmo.ObjectOrientedProgramming.Lab1.ResultModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.TrainModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.RoutePartsModel.Entities;

public class DefaultMagneticRoutePart : RoutePartBase
{
    public DefaultMagneticRoutePart(double distance)
    {
        if (distance <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(distance), "Distance must be greater than zero.");
        }

        Distance = distance;
    }

    public override TrainInteractionResult ContextPass(Train train)
    {
        if (train == null)
        {
            throw new ArgumentNullException(nameof(train), "Object cannot be null.");
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

        return Distance / train.ResultVelocity;
    }
}