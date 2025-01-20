using Itmo.ObjectOrientedProgramming.Lab2.SubjectModel.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectModel.Interfaces;

public interface IExamBuilder
{
    SubjectBuilder WithExam(int points, string name);
}