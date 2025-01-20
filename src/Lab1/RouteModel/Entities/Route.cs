using Itmo.ObjectOrientedProgramming.Lab1.ResultModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.RouteModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.RoutePartsModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.TrainModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteModel.Entities;

public class Route : IRoute
{
    private readonly List<IRoutePart> _routeParts = [];

    public void AddRoutePart(IRoutePart routePart)
    {
        _routeParts.Add(routePart);
    }

    public TrainInteractionResult ProcessTrain(Train train)
    {
        if (train == null)
        {
            throw new ArgumentNullException(nameof(train), "Train cannot be null.");
        }

        TrainInteractionResult result = new TrainInteractionResult.Success();
        foreach (IRoutePart routePart in _routeParts)
        {
            if (routePart == null)
            {
                throw new InvalidCastException("Route part cannot be a null type.");
            }

            result = train.UpdateTrainState(routePart);
            if (result is not TrainInteractionResult.Success)
            {
                return result;
            }
        }

        return result;
    }
}