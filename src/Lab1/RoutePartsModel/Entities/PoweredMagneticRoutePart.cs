using Itmo.ObjectOrientedProgramming.Lab1.ResultModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.TrainModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.RoutePartsModel.Entities;

public class PoweredMagneticRoutePart : RoutePartBase
{
    private double Force { get; }

    public PoweredMagneticRoutePart(double distance, double force)
    {
        if (distance <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(distance), "Distance must be greater than zero.");
        }

        if (force == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(force), "Force cannot be zero.");
        }

        Distance = distance;
        Force = force;
    }

    public override TrainInteractionResult ContextPass(Train train)
    {
        if (train == null)
        {
            throw new ArgumentNullException(nameof(train), "Object cannot be null.");
        }

        if (train.MaxPermissibleForce < double.Abs(Force))
        {
            return new TrainInteractionResult.ExcessiveForceAttachedFailure(Force);
        }

        return CommonPass(train);
    }

    public override void Affect(Train train)
    {
        if (train == null)
        {
            throw new ArgumentNullException(nameof(train), "Object cannot be null.");
        }

        train.CalculateAcceleration(Force);
        train.CalculateResultVelocity();
    }

    public override double ComputePassageTime(Train train)
    {
        if (train == null)
        {
            throw new ArgumentNullException(nameof(train), "Object cannot be null.");
        }

        // D = vt + 0.5 * a * t^2
        if (train.Acceleration != 0)
        {
            return (-train.ResultVelocity +
                    double.Sqrt((train.ResultVelocity * train.ResultVelocity)
                                + (2.0 * train.Acceleration * Distance))) / train.Acceleration;
        }
        else
        {
            return double.Sqrt(2 * train.Mass * Distance / Force);
        }
    }
}