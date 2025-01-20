using Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramModel.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramModel.Interfaces;

public interface ICreditSubjectBuilder
{
    EducationalProgramBuilder WithCreditSubject(string name, int semester);
}