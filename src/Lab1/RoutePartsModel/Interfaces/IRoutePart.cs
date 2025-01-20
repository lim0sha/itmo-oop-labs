using Itmo.ObjectOrientedProgramming.Lab1.ResultModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.TrainModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.RoutePartsModel.Interfaces;

public interface IRoutePart
{
    protected double Distance { get; init; }

    TrainInteractionResult CommonPass(Train train);

    TrainInteractionResult ContextPass(Train train);

    void Affect(Train train);

    double ComputePassageTime(Train train);
}