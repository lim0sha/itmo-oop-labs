using Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramModel.Interfaces;

public interface IEducationalProgramRetriever
{
    EducationalProgram BuildProgram();
}