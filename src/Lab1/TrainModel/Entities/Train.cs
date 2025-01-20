using Itmo.ObjectOrientedProgramming.Lab1.ResultModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.RoutePartsModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.TrainModel.Entities;

public class Train
{
    public double Mass { get; }

    public double ResultVelocity { get; private set; }

    public double Acceleration { get; private set; }

    public double MaxPermissibleForce { get; }

    public double TraversedTime { get; private set; }

    public bool IsTerminalState { get; private set; }

    private double CurrentVelocity { get; set; }

    private double TimeAccuracy { get; }

    public Train(double mass, double maxPermissibleForce, double timeAccuracy)
    {
        if (mass <= 0)
        {
            throw new ArgumentException("Train mass should be positive or equal to zero", nameof(mass));
        }

        if (maxPermissibleForce <= 0)
        {
            throw new ArgumentException("Train maximum permissible force should be positive or equal to zero", nameof(maxPermissibleForce));
        }

        if (timeAccuracy <= 0)
        {
            throw new ArgumentException("Train time accuracy should be positive or equal to zero", nameof(timeAccuracy));
        }

        Mass = mass;
        MaxPermissibleForce = maxPermissibleForce;
        TimeAccuracy = timeAccuracy;
        ResultVelocity = 0;
        CurrentVelocity = 0;
        TraversedTime = 0;
        Acceleration = 0;
        IsTerminalState = false;
    }

    public void CalculateResultVelocity()
    {
        ResultVelocity = CurrentVelocity + (Acceleration * TimeAccuracy);
    }

    public void CalculateAcceleration(double force)
    {
        Acceleration = force / Mass;
    }

    public void CalculateTerminalState()
    {
        CurrentVelocity = 0;
        ResultVelocity = 0;
        Acceleration = 0;
        IsTerminalState = true;
    }

    public TrainInteractionResult UpdateTrainState(IRoutePart routePart)
    {
        if (routePart == null)
        {
            throw new ArgumentNullException(nameof(routePart), "Train cannot be null.");
        }

        CalculateTraversedTime(routePart);
        routePart.Affect(this);
        return routePart.ContextPass(this);
    }

    private void CalculateTraversedTime(IRoutePart routePart)
    {
        if (routePart == null)
        {
            throw new ArgumentNullException(nameof(routePart), "Route part cannot be null.");
        }

        TraversedTime += routePart.ComputePassageTime(this);
    }
}