using Itmo.ObjectOrientedProgramming.Lab2.SubjectModel.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectModel.Interfaces;

public interface ILabworkBuilder
{
    SubjectBuilder WithLabwork(int points, string name);
}