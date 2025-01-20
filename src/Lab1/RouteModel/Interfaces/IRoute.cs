using Itmo.ObjectOrientedProgramming.Lab1.ResultModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.RoutePartsModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.TrainModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteModel.Interfaces;

public interface IRoute
{
    void AddRoutePart(IRoutePart routePart);

    TrainInteractionResult ProcessTrain(Train train);
}