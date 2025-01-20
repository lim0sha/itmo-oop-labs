using Itmo.ObjectOrientedProgramming.Lab1.ResultModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.RouteModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.RoutePartsModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.TrainModel.Entities;
using Xunit;

namespace Lab1.Tests;

public class TrainSystemTests
{
    [Fact]
    public void Scenario1()
    {
        var train = new Train(100, 25, 0.7);
        var route = new Route();
        route.AddRoutePart(new PoweredMagneticRoutePart(10, 20));
        route.AddRoutePart(new DefaultMagneticRoutePart(20));
        route.AddRoutePart(new EndStationRoutePart(20, 10));

        TrainInteractionResult initResult = route.ProcessTrain(train);

        Assert.NotNull(initResult);
        Assert.Equal(initResult, new TrainInteractionResult.Success());
        Assert.Equal(438.57, train.TraversedTime, 0.01);
    }

    [Fact]
    public void Scenario2()
    {
        var train = new Train(100, 25, 0.7);
        var route = new Route();
        route.AddRoutePart(new PoweredMagneticRoutePart(20, 50));
        route.AddRoutePart(new DefaultMagneticRoutePart(20));
        route.AddRoutePart(new EndStationRoutePart(20, 10));

        TrainInteractionResult initResult = route.ProcessTrain(train);

        Assert.NotNull(initResult);
        Assert.Equal(initResult, new TrainInteractionResult.ExcessiveForceAttachedFailure(50));
        Assert.Equal(8.94, train.TraversedTime, 0.01);
    }

    [Fact]
    public void Scenario3()
    {
        var train = new Train(100, 25, 0.9);
        var route = new Route();
        route.AddRoutePart(new PoweredMagneticRoutePart(10, 20));
        route.AddRoutePart(new DefaultMagneticRoutePart(25));
        route.AddRoutePart(new StationRoutePart(10, 10, 15));
        route.AddRoutePart(new DefaultMagneticRoutePart(25));
        route.AddRoutePart(new EndStationRoutePart(20, 10));

        TrainInteractionResult initResult = route.ProcessTrain(train);

        Assert.NotNull(initResult);
        Assert.Equal(initResult, new TrainInteractionResult.Success());
        Assert.Equal(636.11, train.TraversedTime, 0.01);
    }

    [Fact]
    public void Scenario4()
    {
        var train = new Train(1, 75, 0.7);
        var route = new Route();
        route.AddRoutePart(new PoweredMagneticRoutePart(10, 60));
        route.AddRoutePart(new StationRoutePart(10, 3, 25));
        route.AddRoutePart(new DefaultMagneticRoutePart(10));
        route.AddRoutePart(new EndStationRoutePart(20, 1));

        TrainInteractionResult initResult = route.ProcessTrain(train);

        Assert.NotNull(initResult);
        Assert.Equal(initResult, new TrainInteractionResult.StationVelocityLimitFailure(3));
        Assert.Equal(26.05, train.TraversedTime, 0.01);
    }

    [Fact]
    public void Scenario5()
    {
        var train = new Train(10, 1500, 0.7);
        var route = new Route();
        route.AddRoutePart(new PoweredMagneticRoutePart(10, 1500));
        route.AddRoutePart(new DefaultMagneticRoutePart(25));
        route.AddRoutePart(new StationRoutePart(10, 500, 20));
        route.AddRoutePart(new DefaultMagneticRoutePart(10));
        route.AddRoutePart(new EndStationRoutePart(20, 100));

        TrainInteractionResult initResult = route.ProcessTrain(train);

        Assert.NotNull(initResult);
        Assert.Equal(initResult, new TrainInteractionResult.EndStationVelocityLimitFailure(100));
        Assert.Equal(21.26, train.TraversedTime, 0.01);
    }

    [Fact]
    public void Scenario6()
    {
        var train = new Train(10, 1500, 0.7);
        var route = new Route();
        route.AddRoutePart(new PoweredMagneticRoutePart(10, 1250));
        route.AddRoutePart(new DefaultMagneticRoutePart(10));
        route.AddRoutePart(new PoweredMagneticRoutePart(10, 500));
        route.AddRoutePart(new StationRoutePart(10, 50, 20));
        route.AddRoutePart(new DefaultMagneticRoutePart(10));
        route.AddRoutePart(new PoweredMagneticRoutePart(10, 1200));
        route.AddRoutePart(new DefaultMagneticRoutePart(20));
        route.AddRoutePart(new PoweredMagneticRoutePart(10, 100));
        route.AddRoutePart(new EndStationRoutePart(20, 10));

        TrainInteractionResult initResult = route.ProcessTrain(train);

        Assert.NotNull(initResult);
        Assert.Equal(initResult, new TrainInteractionResult.Success());
        Assert.Equal(27.78, train.TraversedTime, 0.01);
    }

    [Fact]
    public void Scenario7()
    {
        var train = new Train(5, 1500, 0.7);
        var route = new Route();
        route.AddRoutePart(new DefaultMagneticRoutePart(25));
        route.AddRoutePart(new EndStationRoutePart(20, 10));

        TrainInteractionResult initResult = route.ProcessTrain(train);

        Assert.NotNull(initResult);
        Assert.Equal(initResult, new TrainInteractionResult.NonMovableConditionFailure());
        Assert.Equal(double.PositiveInfinity, train.TraversedTime);
    }

    [Fact]
    public void Scenario8()
    {
        var train = new Train(10, 500, 0.7);
        var route = new Route();
        route.AddRoutePart(new PoweredMagneticRoutePart(10, 250));
        route.AddRoutePart(new PoweredMagneticRoutePart(10, -500));
        route.AddRoutePart(new EndStationRoutePart(25, 10));

        TrainInteractionResult initResult = route.ProcessTrain(train);

        Assert.NotNull(initResult);
        Assert.Equal(initResult, new TrainInteractionResult.NegativeVelocityConditionFailure());
        Assert.Equal(1.33, train.TraversedTime, 0.01);
    }
}