using Itmo.ObjectOrientedProgramming.Lab2.SubjectModel.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectModel.Interfaces;

public interface ICreditBuilder
{
    SubjectBuilder WithCredit(int points, string name);
}