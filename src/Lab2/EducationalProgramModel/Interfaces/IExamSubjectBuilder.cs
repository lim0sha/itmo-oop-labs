using Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramModel.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramModel.Interfaces;

public interface IExamSubjectBuilder
{
    EducationalProgramBuilder WithExamSubject(string name, int semester);
}